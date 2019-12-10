using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Reminder.Storage.Memory;

namespace Reminder.WebApi.Tests
{
    public class ReminderWebApiTests
    {
        [Test]
        public void WhenCreated_IfSpecifiesValidBody_ShouldReturnResult ()
        {
            var builder = new HostBuilder()
                .ConfigureWebHost(webhost => webhost
                    .UseStartup<Startup>()
                    .UseTestServer())
                .Build();
            var client = builder.GetTestClient();
            var storage = new ReminderStorage(client);
            storage.Add(new ReminderItem)
        }
    }
}