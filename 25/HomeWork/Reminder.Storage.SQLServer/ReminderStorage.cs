using Microsoft.Data.SqlClient;
using System;
using System.Data;


namespace Reminder.Storage.SQLServer
{
    public class ReminderStorage : IReminderStorage
    {
        private string _connectionString;

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
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_AddReminderItem";
            command.Parameters.AddWithValue("@p_id", item.Id);
            command.Parameters.AddWithValue("@p_contact", item.ContactId);
            command.Parameters.AddWithValue("@p_status", (byte)item.Status);
            command.Parameters.AddWithValue("@p_datetime", item.DatetimeUtc);
            command.Parameters.AddWithValue("@p_message", item.Message);

            command.ExecuteNonQuery();

        }
        

        public ReminderItem FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ReminderItem item)
        {
            throw new NotImplementedException();
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public PagedResult FindBy(ReminderItemFilter filter)
        {
            throw new NotImplementedException();
        }

    }
}
