using System.Text;

namespace DurlibCS.Log
{
    public class SimpleTextFileLog : Loggable
    {
        private bool Line = false;
        private bool Formatting = true;
        private string Filename = "";
        public Exception EXCPT = null;
        public SimpleTextFileLog(string filename, bool formatting = true, bool deleteonstart = false)
        {
            Formatting = formatting;
            Filename = filename;
            try
            {
                if (deleteonstart)
                {
                    File.Delete(Filename);
                }
                var file = File.Open(Filename, FileMode.Open);
                file.Close();
            }
            catch (FileNotFoundException e)
            {
                EXCPT = e;

                var file = File.Open(Filename, FileMode.Create);
                file.Close();
            }
            catch (IOException e)
            {
                EXCPT = e;
            }
        }
        public void Log<T>(T text)
        {
            var file = File.Open(Filename, FileMode.Append);
            using (var stream = new StreamWriter(file))
            {
                if (!Line)
                {
                    if (Formatting)
                    {
                        stream.Write("CLIENT [" + DateTime.Now + "]: " + text);
                    }
                    else
                    {
                        stream.Write(text);
                    }
                }
                else
                {
                    if (Formatting)
                    {
                        stream.WriteLine("CLIENT [" + DateTime.Now + "]: " + text);
                    }
                    else
                    {
                        stream.WriteLine(text);
                    }
                }
            }
            //Console.WriteLine($"{text}");
            file.Close();
        }

        public void Log<T>(LogErrorLevel errorLevel, T text) { }

        public void SetEncoding(Encoding type)
        { }
        public void Clear()
        {
            //var file = File.Open(FileName, FileMode.Truncate);
            //file.Close();
        }
        public void LogL<T>(T text)
        {
            Line = true;
            Log(text);
            Line = false;
        }
        public void LogL<T>(LogErrorLevel errorLevel, T text)
        {

        }
    }
}
