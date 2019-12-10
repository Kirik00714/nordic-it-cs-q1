using System;
using Reminder.Domain;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Memory;

namespace Reminder
{
	internal class Program
	{
		static void Main(string[] args)
		{
			WriteLine("Reminder", "enter the Telegram API key");
			var key = Console.ReadLine();

			using var service = new ReminderService(
				storage: new ReminderStorage(),
				sender: new ReminderSender(key),
				receiver: new ReminderReceiver(key),
				parameters: ReminderServiceParameters.Default
			);
			service.ReminderSent += OnReminderSent;
			service.ReminderFailed += OnReminderFailed;

			WriteLine("Reminder", "starting");
			service.Start();
			WriteLine("Reminder", "started. Press any key to stop application");
			Console.ReadKey();
			WriteLine("Reminder", "stopped");
		}

		private static void OnReminderSent(object sender, ReminderSentEventArgs args) =>
			WriteLine("Reminder notification", $"sent with id: {args.Id:N}");

		private static void OnReminderFailed(object sender, ReminderFailedEventArgs args) =>
			WriteLine("Reminder notification", $"sent with id: {args.Id:N}, error: {args.Exception}");

		private static void WriteLine(string type, string message) =>
			Console.WriteLine($"({DateTimeOffset.UtcNow}) [{type}] {message}");
	}
}
