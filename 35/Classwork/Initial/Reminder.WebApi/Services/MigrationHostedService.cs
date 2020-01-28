using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Reminder.Storage.SqlServer.Ef;
using System.Threading;
using System.Threading.Tasks;

namespace Reminder.WebApi.Services
{
    public class MigrationHostedService : IHostedService
    {
        private readonly ReminderStorageContext _context;
        public MigrationHostedService(ReminderStorageContext context)
        {
            _context = context;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _context.Database.Migrate();
            _context.Dispose();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
