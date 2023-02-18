namespace DurlibCS.Parse
{
    public class ParseJson
    {
         private string filename = "";
        private string filepath = "";
        private string output = "";
        private DOCTYPE type = DOCTYPE.TXT;
        public Exception EXCPT = null;
        public ParseJson(string filename)
        {
            try
            {
                var file = File.Open(filename, FileMode.Open);
                file.Close();
            }
            catch (FileNotFoundException e)
            {
                EXCPT = e;

                throw new NullReferenceException();
            }
            catch (IOException e)
            {
                EXCPT = e;
            }
        }
        public T Parse<T>(T obj)
        {
            return obj;
        }
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }

        public string Filepath
        {
            get { return filepath; }
            set { filepath = value; }
        }

        public string Output
        {
            get { return output; }
            set { output = value; }
        }
    }
}