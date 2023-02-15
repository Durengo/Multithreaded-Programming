using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace durlibcsharp
{
    public static class durlibsharplog
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
