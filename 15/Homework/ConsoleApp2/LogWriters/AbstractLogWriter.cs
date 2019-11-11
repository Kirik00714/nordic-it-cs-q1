using System;

namespace ConsoleApp2
{
    abstract class AbstractLogWriter : ILogWriter
    {

        public void LogInfo(string message) =>
            LogMessage(message, "Info");
        public void LogWarning(string message) =>
            LogMessage(message, "Warning");
        public void LogError(string message) =>
            LogMessage(message, "Error");
        protected string OutputMessage(string message, string type) =>
            $"{DateTime.Now}  {type}:   {message}";
        protected abstract void WriteMessage(string line);

        protected void LogMessage(string message, string type) =>
            WriteMessage(OutputMessage(message, type));
    }
}
