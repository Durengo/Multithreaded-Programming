using System.Text;

namespace DurlibCS.Log
{
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class JsonLog : Loggable
    {
        //private File JsonFile = null;
        private bool Line = true;
        //private bool Formatting = true;
        private string FileName = "";
        public Exception EXCPT = null;
        private JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public JsonLog(string filename)
        {
            FileName = filename;
            try
            {
                File.Delete(FileName);
                // var file = File.Open(FileName, FileMode.Open);
                // file.Close();
                var file = File.Open(FileName, FileMode.Create);
                file.Close();
            }
            catch (FileNotFoundException e)
            {
                EXCPT = e;

                var file = File.Open(FileName, FileMode.Create);
                file.Close();
            }
            catch (IOException e)
            {
                EXCPT = e;
            }
        }

        public void Log<T>(T text)
        {
            var file = File.Open(FileName, FileMode.Append);
            using (var stream = new StreamWriter(file))
            {
                if (!Line)
                {
                    stream.Write(JsonSerializer.Serialize(text, JsonOptions));
                }
                else
                {
                    stream.WriteLine(JsonSerializer.Serialize(text, JsonOptions));
                }
                
            }
            //Console.WriteLine($"{text}");
            file.Close();
        }

        public void Log<T>(LogErrorLevel errorLevel, T text) { }

        public void LogL<T>(T text)
        {
            //Line = true;
            Log(text);
            //Line = false;
        }
        public void LogL<T>(LogErrorLevel errorLevel, T text) { }

        public void SetEncoding(Encoding type) { }

        public void Clear()
        {
            var file = File.Open(FileName, FileMode.Truncate);
            file.Close();
        }
    }
}
