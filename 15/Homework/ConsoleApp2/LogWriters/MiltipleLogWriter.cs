namespace ConsoleApp2
{
    class MiltipleLogWriter : ILogWriter
    {
        public MiltipleLogWriter(params ILogWriter[] ilogwriters)
        {
            this._ilogwriters = ilogwriters;
        }
        private readonly ILogWriter[] _ilogwriters;

        public void LogInfo(string message)
        {
            foreach (var ilogwriter in _ilogwriters)
            {
                ilogwriter.LogInfo(message);
            }
        }
        public void LogWarning(string message)
        {
            foreach (var ilogwriter in _ilogwriters)
            {
                ilogwriter.LogWarning(message);
            }
        }
        public void LogError(string message)
        {
            foreach (var ilogwriter in _ilogwriters)
            {
                ilogwriter.LogError(message);
            }
        }
    }
}
