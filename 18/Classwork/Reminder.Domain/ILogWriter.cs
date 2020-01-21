using System;
using System.Collections.Generic;
using System.Text;
using Reminder.Storage;

namespace Reminder.Domain
{
    interface ILogWriter
    {
     
        void LogWriter(string message);

    }
}
