using DurlibCS.Log;
namespace DurlibCS.Input
{
    public static class Input
    {
        static Logger InputLogger = new Logger(new ConsoleLog());

        public static int GIBI()
        {
            int converted;
            while (true)
            {
                try
                {
                    converted = int.Parse(Console.ReadLine() + "");
                    return converted;
                }
                catch (ArgumentNullException e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
                catch (OverflowException e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
                catch (FormatException e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
                catch (Exception e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
            }
        }

        public static int GIBI(int min, int max)
        {
            while (true)
            {
                int input = GIBI();
                if (input >= min && input <= max)
                {
                    return input;
                }
                else
                {
                    InputLogger.Log(
                        LogErrorLevel.ERROR,
                        $"EXCEPTION! INPUT OUT OF RANGE: {input} in [MIN]{min}-[MAX]{max}\nTRY AGAIN"
                    );
                }
            }
            //Log.FATAL("GIBI(int min, int max) - REACHED END OF CONTROL");
            //return -1;
        }

        public static double GIBD()
        {
            double converted;
            while (true)
            {
                try
                {
                    converted = double.Parse(Console.ReadLine() + "");
                    return converted;
                }
                catch (ArgumentNullException e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
                catch (OverflowException e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
                catch (FormatException e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
                catch (Exception e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
            }
        }

        public static double GIBD(int min, int max)
        {
            while (true)
            {
                double input = GIBD();
                if (input >= min && input <= max)
                {
                    return input;
                }
                else
                {
                    InputLogger.Log(
                        LogErrorLevel.ERROR,
                        $"EXCEPTION! INPUT OUT OF RANGE: {input} in [MIN]{min}-[MAX]{max}\nTRY AGAIN"
                    );
                }
            }
            // Log.FATAL("GIBI(int min, int max) - REACHED END OF CONTROL");
            // return -1;
        }

        public static float GIBF()
        {
            float converted;
            while (true)
            {
                try
                {
                    converted = float.Parse(Console.ReadLine() + "");
                    return converted;
                }
                catch (ArgumentNullException e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
                catch (OverflowException e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
                catch (FormatException e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
                catch (Exception e)
                {
                    InputLogger.Log(LogErrorLevel.ERROR, e);
                }
            }
        }

        public static float GIBF(int min, int max)
        {
            while (true)
            {
                float input = GIBF();
                if (input >= min && input <= max)
                {
                    return input;
                }
                else
                {
                    InputLogger.Log(
                        LogErrorLevel.ERROR,
                        $"EXCEPTION! INPUT OUT OF RANGE: {input} in [MIN]{min}-[MAX]{max}\nTRY AGAIN"
                    );
                }
            }
            // Log.FATAL("GIBI(int min, int max) - REACHED END OF CONTROL");
            // return -1;
        }

        public static bool GetYesOrNo()
        {
            while (true)
            {
                InputLogger.Log(LogErrorLevel.INFO, "(Y/y/1/Enter or N/n/0/Escape) PRESS KEY:");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y || key == ConsoleKey.D1 || key == ConsoleKey.Enter)
                {
                    InputLogger.Log(LogErrorLevel.TRACE, "");
                    InputLogger.Log(LogErrorLevel.INFO, $"KEY PRESSED = {key}");
                    return true;
                }
                else if (key == ConsoleKey.N || key == ConsoleKey.D0 || key == ConsoleKey.Escape)
                {
                    InputLogger.Log(LogErrorLevel.TRACE, "");
                    InputLogger.Log(LogErrorLevel.INFO, $"KEY PRESSED = {key}");
                    return false;
                }
                InputLogger.Log(LogErrorLevel.TRACE, "");
            }
        }

        public static string GIBS()
        {
            return Console.ReadLine() + "";
        }

        public static string GIBS_NW()
        {
            string text = Console.ReadLine() + "";
            text = String.Concat(text.Where(c => !Char.IsWhiteSpace(c)));
            return text;
        }

        public static string ValidateName()
        {
            string input;
            bool valid = false;
            do
            {
                input = GIBS();
                valid = InputValidation.NameValidation(input);
                if (!valid)
                {
                    InputLogger.Log(
                        LogErrorLevel.ERROR,
                        "THIS DATA CANNOT HAVE:\n1.MORE THAN ONE CAPITAL LETTER;\n2.A LOWERCASE FIRST LETTER;\n3.ANY NUMBERS;\n4.ANY SYMBOLS;\n5. WHITESPACE\nTry again."
                    );
                }
            } while (!valid);
            return input;
        }
    }
}
