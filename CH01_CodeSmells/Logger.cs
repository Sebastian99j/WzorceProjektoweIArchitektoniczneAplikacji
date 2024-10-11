namespace CodeSmells
{
    internal class Logger
    {
        private string FormatLogMessage(string logType, string message, DateTime timestamp)
        {
            string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
            return $"{logType}: [{formattedTimestamp}] {message}";
        }

        public void LogError(string message, DateTime timestamp)
        {
            string formattedMessage = FormatLogMessage("ERROR", message, timestamp);
            Console.WriteLine(formattedMessage);
        }

        public void LogWarning(string message, DateTime timestamp)
        {
            string formattedMessage = FormatLogMessage("WARNING", message, timestamp);
            Console.WriteLine(formattedMessage);
        }
    }
}
