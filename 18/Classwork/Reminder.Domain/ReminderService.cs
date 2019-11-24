using System;
using System.Threading;
using Reminder.Sender;
using Reminder.Storage;
using Reminder.Receiver;

namespace Reminder.Domain
{
    public class ReminderServiceParameters
    {
        public static ReminderServiceParameters Default =>
            new ReminderServiceParameters(
                TimeSpan.FromSeconds(1),
                TimeSpan.Zero,
                TimeSpan.FromSeconds(1),
                TimeSpan.Zero);

        public ReminderServiceParameters(
            TimeSpan createTimerInterval,
            TimeSpan createTimerDelay,
            TimeSpan readyTimerInterval,
            TimeSpan readyTimerDelay)
        {
            CreateTimerInterval = createTimerInterval;
            CreateTimerDelay = createTimerDelay;
            ReadyTimerInternval = readyTimerInterval;
            ReadyTimerDelay = readyTimerDelay;
        }

        public TimeSpan CreateTimerInterval { get; }
        public TimeSpan CreateTimerDelay { get; }
        public TimeSpan ReadyTimerInternval { get; }
        public TimeSpan ReadyTimerDelay { get; }
    }
    public class ItemFailedEventArgs : EventArgs
    {
        public Guid Id { get; }
        public NotificationException Exception { get; set; }

        public ItemFailedEventArgs(Guid id, NotificationException exception)
        {
            Id = id;
            Exception = exception;
        }
    }
    public class ItemSentEventArgs : EventArgs
    {
        public Guid Id { get; }

        public ItemSentEventArgs(Guid id)
        {
            Id = id;
        }
    }
    public class ReminderService : IDisposable
    {
        public event EventHandler<ItemSentEventArgs> ItemSent;
        public event EventHandler<ItemFailedEventArgs> ItemFailed;

        private readonly IReminderStorage _storage;
        private readonly IReminderSender _sender;
        private readonly IReminderReceiver _receiver;
        private readonly ReminderServiceParameters _parameters;
        private Timer _createdItemTimer;
        private Timer _readyItemTimer;

        public ReminderService(
            IReminderStorage storage,
            IReminderSender sender,
            IReminderReceiver receiver,
            ReminderServiceParameters parameters)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            _receiver.MessageReceived += OnMessageReceived;
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public void Start()
        {
            _createdItemTimer = new Timer(OnCreatedItemTimerTick, null,
                _parameters.CreateTimerDelay,
                _parameters.CreateTimerInterval);
            _readyItemTimer = new Timer(OnReadyItemTimerTick, null,
                _parameters.ReadyTimerDelay,
                _parameters.ReadyTimerInternval);
        }

        public void Dispose()
        {
            _createdItemTimer.Dispose();
            _readyItemTimer.Dispose();
            _receiver.MessageReceived -= OnMessageReceived;
        }

        private void OnCreatedItemTimerTick(object _)
        {
            var filter = ReminderItemFilter
                .ByStatus(ReminderItemStatus.Created)
                .At(DateTimeOffset.Now);
            var items = _storage.FindBy(filter);

            foreach (var item in items)
            {
                _storage.Update(item.ReadyToSend());
            }
        }

        private void OnReadyItemTimerTick(object _)
        {
            var filter = ReminderItemFilter.ByStatus(ReminderItemStatus.Ready);
            var items = _storage.FindBy(filter);

            foreach (var item in items)
            {
                try
                {
                    var notification = new Notification(
                        item.ContactId,
                        item.Message,
                        item.MessageDate);

                    _sender.Send(notification);
                    OnItemSent(item);
                }
                catch (NotificationException exception)
                {
                    OnItemFailed(item, exception);
                }
            }
        }

        private void OnItemSent(ReminderItem item)
        {
            _storage.Update(item.Sent());
            ItemSent?.Invoke(this, new ItemSentEventArgs(item.Id));
        }

        private void OnItemFailed(ReminderItem item, NotificationException exception)
        {
            _storage.Update(item.Failed());
            ItemFailed?.Invoke(this, new ItemFailedEventArgs(item.Id, exception));
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            var item = new ReminderItem(
                Guid.NewGuid(),
                args.ContactId,
                args.Message.Text,
                args.Message.Datetime);

            _storage.Create(item);
        }
    }
}

