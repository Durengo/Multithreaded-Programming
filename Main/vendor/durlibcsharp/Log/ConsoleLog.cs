using System.Text;

namespace DurlibCS.Log
{
    using System.Diagnostics;

    public class ConsoleLog : Loggable
    {
        private bool Line = false;
        private ConsoleColor LastProvidedForegroundColor;
        private ConsoleColor LastProvidedBackgroundColor;

        public void Log<T>(T text)
        {
            if(!Line)
            {
                Console.Write($"{text}");
            }
            else
            {
                Console.WriteLine($"{text}");
            }
        }

        public void Log<T>(LogErrorLevel errorLevel, T text)
        {
            switch (errorLevel)
            {
                case LogErrorLevel.TRACE:
                    TRACE(text);
                    break;
                case LogErrorLevel.INFO:
                    INFO(text);
                    break;
                case LogErrorLevel.WARN:
                    WARN(text);
                    break;
                case LogErrorLevel.ERROR:
                    ERROR(text);
                    break;
                case LogErrorLevel.FATAL:
                    FATAL(text);
                    break;
                default:
                    TRACE(text);
                    break;
            }
        }

        public void LogL<T>(T text)
        {
            Line = true;
            Log(text);
            Line = false;
        }
        public void LogL<T>(LogErrorLevel errorLevel, T text)
        {
            Line = true;
            Log(errorLevel, text);
            Line = false;
        }
        public void SetEncoding(Encoding type)
        {
            Console.OutputEncoding = type;
        }
        public void LogColorText(string text, ConsoleColor ForegroundColor)
        {
            ResetConsoleColor();
            SetConsoleForegroundColor(ForegroundColor);
            Log(text);
        }
        public void LogColorBackground(string text, ConsoleColor BackgroundColor)
        {
            ResetConsoleColor();
            SetConsoleBackgroundColor(BackgroundColor);
            Log(text);
        }
        public void LogColorForegroundAndBackground(
            string text,
            ConsoleColor ForegroundColor,
            ConsoleColor BackgroundColor
        )
        {
            ResetConsoleColor();
            SetConsoleForegroundColor(ForegroundColor);
            SetConsoleBackgroundColor(BackgroundColor);
            Log(text);
        }
        public void ERROR<T>(T text)
        {
            ResetConsoleColor();
            SetConsoleForegroundColor(ConsoleColor.Red);
            Log(text);
            ResetConsoleColor();
        }
        public void WARN<T>(T text)
        {
            ResetConsoleColor();
            SetConsoleForegroundColor(ConsoleColor.Yellow);
            Log(text);
            ResetConsoleColor();
        }
        public void INFO<T>(T text)
        {
            ResetConsoleColor();
            SetConsoleForegroundColor(ConsoleColor.Green);
            Log(text);
            ResetConsoleColor();
        }
        public void TRACE<T>(T text)
        {
            ResetConsoleColor();
            Log(text);
            ResetConsoleColor();
        }
        public void FATAL<T>(T text)
        {
            ResetConsoleColor();
            SetConsoleForegroundColor(ConsoleColor.Magenta);
            Log(text);
            Debug.Assert(false, text.ToString());
            ResetConsoleColor();
        }
        private void SetConsoleForegroundColor(ConsoleColor c)
        {
            LastProvidedForegroundColor = c;
            Console.ForegroundColor = LastProvidedForegroundColor;
        }
        private void SetConsoleBackgroundColor(ConsoleColor c)
        {
            LastProvidedBackgroundColor = c;
            Console.BackgroundColor = LastProvidedBackgroundColor;
        }
        private void ResetConsoleColor()
        {
            Console.ResetColor();
        }
        private void ResetConsoleForegroundColor()
        {
            ResetConsoleColor();
            Console.BackgroundColor = LastProvidedBackgroundColor;
        }
        private void ResetConsoleBackgroundColor()
        {
            ResetConsoleColor();
            Console.ForegroundColor = LastProvidedForegroundColor;
        }
        public void Clear() { }
    }
}
