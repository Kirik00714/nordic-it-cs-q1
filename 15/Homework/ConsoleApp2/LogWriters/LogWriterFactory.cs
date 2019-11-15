namespace ConsoleApp2
{
    class LogWriterFactory
    {
        private static LogWriterFactory instance;
        private LogWriterFactory()
        { }
        public static LogWriterFactory GetInstance
        {
            get
            {
                return instance ??
                    (instance = new LogWriterFactory());
            }
        }
        public ILogWriter GetLogWriter<T>(object parameters) where T : ILogWriter
        {

            if (typeof(T) == typeof(ConsoleLogWriter))
            {
                return new ConsoleLogWriter();
            }
            else if (typeof(T) == typeof(FileLogWriter))
            {
                if (!string.IsNullOrWhiteSpace((string)parameters))
                {
                    return new FileLogWriter((string)parameters);
                }
                else
                {
                    return null;
                }
            }
            else if (typeof(T) == typeof(MiltipleLogWriter))
            {
                return new MiltipleLogWriter((ILogWriter[])parameters);
            }
            else
            {
                return null;
            }

        }       

    }
    
}
