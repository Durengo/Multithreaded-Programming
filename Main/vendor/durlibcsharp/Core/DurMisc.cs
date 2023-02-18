namespace DurlibCS.Log
{
    public static class DurLog
    {
        private static Logger log = new Logger(new ConsoleLog());
        public static void Log<T>(T text)
        {
            log.Log(text);
        }
        public static void Log<T>(LogErrorLevel errorLevel, T text)
        {
            log.Log(errorLevel, text);
        }
        public static void LogL<T>(T text)
        {
            log.LogL(text);
        }
        public static void LogL<T>(LogErrorLevel errorLevel, T text)
        {
            log.LogL(errorLevel, text);
        }
    }
}
namespace DurlibCS.Input
{
    using DurlibCS.Log;
    public class DurMisc
    {
        public static void AnyKeyExit()
        {
            Logger CLog = new Logger(new ConsoleLog());
            CLog.Log(LogErrorLevel.ERROR, "PRESS ANY KEY TO EXIT.");
            Console.ReadKey();
        }
    }
}