using System;
using System.Collections.Generic;
using System.Text;
using Reminder.Storage;

namespace Reminder.Domain
{
    interface ILogWriter
    {
        void LogCreated(string message);
        void LogReady(string message);
        void LogSent(string message);
        void LogFailed(string message);

    }
}
