using Microsoft.Extensions.Hosting;
using Reminder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reminder.WebApi.Services
{
    public class ReminderHostedService : IHostedService
    {
        private readonly ReminderService _service;
        public ReminderHostedService(ReminderService service)
        {
            _service = service;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _service.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _service.Dispose();
            return Task.CompletedTask;
        }
    }
}
