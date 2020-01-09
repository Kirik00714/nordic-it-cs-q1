using Microsoft.Data.SqlClient;
using NUnit.Framework;
using System;
using System.Data;

namespace Reminder.Storage.SQLServer.Tests
{

    public class ReminderStorageCreator
    {
        private string _connectionString;

        public ReminderStorageCreator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTables()
        {
            ExecuteScript(SQL.CreateContactTable); 
            ExecuteScript(""); 
            ExecuteScript(""); 
            ExecuteScript("");
        }
        public void CreateProcedure()
        {

        }
        public void DropTables()
        {

        }
        public void DropProcedure()
        {

        }

        private void ExecuteScript(string sqript)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = "";
        }
    }
    public class ReminderStorageTests 
    {
        public ReminderStorageCreator Creator { get; } =
            new ReminderStorageCreator("");

        [OneTimeSetUp]
        public void Setup()
        {
            Creator.CreateTables();
            Creator.CreateProcedure();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            Creator.DropTables();
            Creator.DropProcedure();
        }

        [Test]
        public void Test1()
        {
            
        }
    }
}