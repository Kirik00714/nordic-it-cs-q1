namespace ConsoleApp2
{
    class MiltipleLogWriter : ILogWriter
    {
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
