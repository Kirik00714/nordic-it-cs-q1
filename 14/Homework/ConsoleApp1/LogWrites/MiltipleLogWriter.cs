namespace ConsoleApp1
{
    class MiltipleLogWriter : ILogWriter
    {
        private static MiltipleLogWriter instance;
        private MiltipleLogWriter()
        { }
        public static MiltipleLogWriter GetInstance(params ILogWriter[] ilogwriters)
        {
            return instance ??
                (instance = new MiltipleLogWriter());
        }
        public MiltipleLogWriter(params ILogWriter[] ilogwriters)
        {
            this.ilogwriters = ilogwriters;
        }
        private readonly ILogWriter[] ilogwriters;

        public void LogInfo(string message)
        {
            foreach (var ilogwriter in ilogwriters)
            {
                ilogwriter.LogInfo(message);
            }
        }
        public void LogWarning(string message)
        {
            foreach (var ilogwriter in ilogwriters)
            {
                ilogwriter.LogWarning(message);
            }
        }
        public void LogError(string message)
        {
            foreach (var ilogwriter in ilogwriters)
            {
                ilogwriter.LogError(message);
            }
        }
    }
}
