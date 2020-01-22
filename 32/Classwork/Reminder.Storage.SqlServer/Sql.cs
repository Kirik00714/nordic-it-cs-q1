using System.Data;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.FileProviders;

namespace Reminder.Storage.SqlServer
{
	public static class Sql
	{
		public static string CreateContactTable =>
			ReadScript(nameof(CreateContactTable));

		public static string CreateReminderItemStatusTable =>
			ReadScript(nameof(CreateReminderItemStatusTable));

		public static string CreateReminderItemTable =>
			ReadScript(nameof(CreateReminderItemTable));

		public static string InsertReminderItemStatusLines =>
			ReadScript(nameof(InsertReminderItemStatusLines));

		public static string AddReminderItem =>
			ReadScript(nameof(AddReminderItem));

		public static string FindReminderItem =>
			ReadScript(nameof(FindReminderItem));

		public static string FindReminderItemCount =>
			ReadScript(nameof(FindReminderItemCount));

		public static string FindReminderItems =>
			ReadScript(nameof(FindReminderItems));

		public static string UpdateReminderItem =>
			ReadScript(nameof(UpdateReminderItem));
		public static string DeleteReminderItem =>
			ReadScript(nameof(DeleteReminderItem));
		public static string ClearReminderItem =>
			ReadScript(nameof(ClearReminderItem));

		public static SqlConnection CreateConnection(string connectionString)
		{
			var connection = new SqlConnection(connectionString);
			connection.Open();
			return connection;
		}

		public static SqlCommand CreateQuery(this SqlConnection connection, string query)
		{
			var command = connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = query;
			return command;
		}

		public static SqlCommand CreateProcedure(this SqlConnection connection, string procedure)
		{
			var command = connection.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = procedure;
			return command;
		}

		private static string ReadScript(string name)
		{
			var provider = new EmbeddedFileProvider(typeof(Sql).Assembly);
			var info = provider.GetFileInfo($"Scripts\\{name}.sql");

			using var stream = info.CreateReadStream();
			using var reader = new StreamReader(stream);
			return reader.ReadToEnd();
		}
	}
}
