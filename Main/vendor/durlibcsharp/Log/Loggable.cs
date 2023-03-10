using System.Text;

namespace DurlibCS.Log
{
    public enum LogErrorLevel
    {
        TRACE = 0,
        INFO = 1,
        WARN = 2,
        ERROR = 3,
        FATAL = 4
    }

    public interface Loggable
    {
        void Log<T>(T text);
        void Log<T>(LogErrorLevel errorLevel, T text);
        void LogL<T>(T text);
        void LogL<T>(LogErrorLevel errorLevel, T text);
        void SetEncoding(Encoding type);
        void Clear();
    }
}
