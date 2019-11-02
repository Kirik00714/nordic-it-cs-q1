using System;

namespace ConsoleApp1
{
    abstract class AbstractLogWriter : ILogWriter
    {
        
        public virtual void LogInfo(string message)
        {
            OutputMessage( message);
        }
        public virtual void LogWarning(string message)
        {
            OutputMessage(message);
        }
        public virtual  void LogError(string message)
        {
            OutputMessage(message);
        }
        public virtual string OutputMessage(string message)
        {
            return  $"{DateTime.Now}  Info:   {message}";
        }

    }
}
