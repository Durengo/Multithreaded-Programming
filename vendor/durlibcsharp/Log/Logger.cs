using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace durlibcsharp
{
    public class Logger
    {
        private Loggable LogType;

        public Logger(Loggable logType)
        {
            if (logType == null)
                throw new ArgumentNullException();
            LogType = logType;
        }
        public void Log<T>(T text)
        {
            LogType.Log(text);
        }
        public void Log<T>(LogErrorLevel errorLevel, T text)
        {
            LogType.Log(errorLevel, text);
        }
        public void LogL<T>(T text)
        {
            LogType.LogL(text);
        }
        public void LogL<T>(LogErrorLevel errorLevel, T text)
        {
            LogType.LogL(errorLevel, text);
        }
        public void Clear()
        {
            LogType.Clear();
        }
        public void SetEncoding(Encoding type)
        {
            LogType.SetEncoding(type);
        }
        public Loggable Type
        {
            get { return LogType; }
        }
    }
}
