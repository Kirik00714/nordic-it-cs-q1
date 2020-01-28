using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using Reminder.Storage.Exceptions;

namespace Reminder.Storage.SqlServer
{
	public class ReminderStorage : IReminderStorage
	{
		private readonly string _connectionString;

		public ReminderStorage(string connectionString)
		{
			if (string.IsNullOrWhiteSpace(connectionString))
			{
				throw new ArgumentException("message", nameof(connectionString));
			}

			_connectionString = connectionString;
		}

		public void Add(ReminderItem item)
		{
			using var connection = Sql.CreateConnection(_connectionString);
			using var command = connection.CreateProcedure("sp_AddReminderItem");

			command.Parameters.AddWithValue("@p_id", item.Id);
			command.Parameters.AddWithValue("@p_contact", item.ContactId);
			command.Parameters.AddWithValue("@p_status", (byte) item.Status);
			command.Parameters.AddWithValue("@p_datetime", item.DatetimeUtc);
			command.Parameters.AddWithValue("@p_message", item.Message);

			try
			{
				command.ExecuteNonQuery();
			}
			catch (SqlException exception) when (exception.Number == 2627)
			{
				throw new ReminderItemDuplicateException(item.Id);
			}
		}

		public ReminderItem FindById(Guid id)
		{
			using var connection = Sql.CreateConnection(_connectionString);
			using var command = connection.CreateQuery(Sql.FindReminderItem);

			command.Parameters.AddWithValue("@p_id", id);

			var items = ExecuteReader(command);
			if (items.Count == 0)
			{
				throw new ReminderItemNotFoundException(id);
			}
			return items[0];
		}

		public void Update(ReminderItem item)
		{
			using var connection = Sql.CreateConnection(_connectionString);
			using var command = connection.CreateQuery(Sql.UpdateReminderItem);

			command.Parameters.AddWithValue("@p_id", item.Id);
			command.Parameters.AddWithValue("@p_status", (byte)item.Status);
			command.Parameters.AddWithValue("@p_datetime", item.DatetimeUtc);
			command.Parameters.AddWithValue("@p_message", item.Message);
			var isUpdated = command.Parameters.Add("@p_updated", SqlDbType.Bit);
			isUpdated.Direction = ParameterDirection.Output;

			command.ExecuteNonQuery();

			if (!(bool)isUpdated.Value)
			{
				throw new ReminderItemNotFoundException(item.Id);
			}
		}

		public void Delete(Guid id)
		{
			using var connection = Sql.CreateConnection(_connectionString);
			using var command = connection.CreateProcedure("sp_DeleteReminderItem");

			command.Parameters.AddWithValue("@p_id", id);
			command.ExecuteNonQuery();
			if (id == Guid.Empty)
			{
				throw new ReminderItemNotFoundException(id);
			}
			 
			
		}


		public void Clear()
		{
			using var connection = Sql.CreateConnection(_connectionString);
			using var command = connection.CreateProcedure("sp_ClearReminderItem");
			command.ExecuteNonQuery();
			
		}

		public PagedResult FindBy(ReminderItemFilter filter)
		{
			using var connection = Sql.CreateConnection(_connectionString);

			var items = GetReminderItems(connection, filter);
			var count = GetReminderItemsCount(connection, filter);

			return new PagedResult(count, filter.Page, items);
		}

		private List<ReminderItem> GetReminderItems(
			SqlConnection connection,
			ReminderItemFilter filter)
		{
			var predicate = GeneratePredicate(filter);
			var offset = (filter.Page.Number - 1) * filter.Page.Size;
			var limit = filter.Page.Size;
			var script = Sql.FindReminderItems
				.Replace("{predicate}", predicate)
				.Replace("{offset}", offset.ToString())
				.Replace("{limit}", limit.ToString());

			using var command = connection.CreateQuery(script);

			return ExecuteReader(command);
		}

		private int GetReminderItemsCount(
			SqlConnection connection,
			ReminderItemFilter filter)
		{
			var predicate = GeneratePredicate(filter);
			var script = Sql.FindReminderItemCount
				.Replace("{predicate}", predicate);

			using var command = connection.CreateQuery(script);
			using var reader = command.ExecuteReader();
			reader.Read();

			return reader.GetInt32("Count");
		}

		private List<ReminderItem> ExecuteReader(SqlCommand command)
		{
			using var reader = command.ExecuteReader();

			var items = new List<ReminderItem>();
			var id = reader.GetOrdinal("Id");
			var contact = reader.GetOrdinal("Login");
			var message = reader.GetOrdinal("Message");
			var datetime = reader.GetOrdinal("DatetimeUtc");
			var status = reader.GetOrdinal("StatusId");

			while (reader.Read())
			{
				var item = new ReminderItem(
					reader.GetGuid(id),
					reader.GetString(contact),
					reader.GetString(message),
					reader.GetDateTimeOffset(datetime),
					(ReminderItemStatus)reader.GetByte(status)
				);
				items.Add(item);
			}

			return items;
		}

		private string GeneratePredicate(ReminderItemFilter filter)
		{
			var list = new List<string>();

			if (filter.ByStatus)
			{
				list.Add($"RI.StatusId = {filter.Status:N}");
			}
			if (filter.ByDatetime)
			{
				list.Add($"RI.DatetimeUtc < '{filter.DatetimeUtc}'");
			}

			return list.Count == 0
				? string.Empty
				: $"WHERE {string.Join(" AND ", list)}";
		}
	}
}
