using System;

namespace ConsoleApp1
{
    abstract class AbstractLogWriter : ILogWriter
    {
        protected string Message { get; set; }
        public virtual void LogInfo(string message)
        {
            Message = $"{DateTime.Now}  Info:   {message}";
        }
        public virtual void LogWarning(string message)
        {
            Message = $"{DateTime.Now}  Warning:   {message}";
        }
        public virtual  void LogError(string message)
        {
            Message = $"{DateTime.Now}  Error:   {message}";
        }

    }
}
