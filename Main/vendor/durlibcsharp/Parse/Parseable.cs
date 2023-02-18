namespace DurlibCS.Parse
{
    public enum DOCTYPE
    {
        TXT = 0,
        JSON = 1
    }
    public interface Parseable
    {
        public T Parse<T>(T obj);
        public void Parse(string parseSettings);
        public void Parse(string[] parseSettings);

        public string Filename
        {
            get;
            set;
        }
        public string Filepath
        {
            get;
            set;
        }
        public string Output
        {
            get;
            set;
        }
        // public ConcurrentQueue<string[]> ParsedOutputList
        // {
        //     get;
        //     set;
        // }
        // public List<string> ParsedOutput
        // {
        //     get;
        //     set;
        // }
        public List<string[]> ParsedOutput
        {
            get;
            set;
        }
    }
}
