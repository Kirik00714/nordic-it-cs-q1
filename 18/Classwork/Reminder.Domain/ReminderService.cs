using System;
using System.Threading;
using Reminder.Storage;

namespace Reminder.Domain
{
    public class CreateReminderModul
    {
        public string contactId { get; set; }
        public string message { get; set; }
        public DateTimeOffset messageData { get; set; }
    }

    public class ReminderModelEventArgs : EventArgs
    {
        public string contactId
    }


    public class RemiinderService
    {
        public event EventHandler<ReminderModelEventArgs> ReminderitemFired;
        private readonly Timer _createdItemTimer;

        private readonly IReminderStorage _storage;
        private readonly Timer _readyItemTimer;

        public ReminderService(IReminderStorage storage)
        {
            _storage = storage;
            _createdItemTimer = new Timer(OnTimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            _readyItemTimer = new Timer(OnReadyItemTimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));


        }

        public void Create(CreateReminderModul model)
        {
            var item = new ReminderItem(Guid.NewGuid(),model.contactId,model.message,model.messageData);
            _storage.Create(item);
        }

        private void OnTimerTick(object state)
        {
            
            var filter = new ReminderItemFilter().At(DateTimeOffset.Now).Created());
            var items = _storage.FindBy(filter);
            foreach (var item in items)
            {
                
                _storage.Update(item.ReadyToSend());
            }



        }
        private void OnReadyItemTimerTick(object state)
        {

            var filter = new ReminderItemFilter().Ready();
            var items = _storage.FindBy(filter);
            foreach (var item in items)
            {

                ReminderitemFired?.Invoke(this, new ReminderModelEventArgs(item));
            }



        }


    }
}
