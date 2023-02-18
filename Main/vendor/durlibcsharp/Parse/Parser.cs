namespace DurlibCS.Parse
{
    public class Parser
    {
        private Parseable ParserType;

        public Parser(Parseable parserType)
        {
            if (parserType == null)
            {
                throw new ArgumentNullException();
            }
            ParserType = parserType;
        }
        // public T Parse<T>(T obj)
        // {
        //     return ParserType.Parse(obj);
        // }
        public void Parse(string parseSettings)
        {

            ParserType.Parse(parseSettings);
        }
        public void Parse(string[] parseSettings)
        {
            ParserType.Parse(parseSettings);
        }
        public string Filename
        {
            get { return ParserType.Filename; }
            set { ParserType.Filename = value; }
        }
        public string Filepath
        {
            get { return ParserType.Filepath; }
            set { ParserType.Filepath = value; }
        }
        public string Output
        {
            get { return ParserType.Output; }
            set { ParserType.Output = value; }
        }
        // public ConcurrentQueue<string[]> ParsedOutputList
        // {
        //     get { return ParserType.ParsedOutputList; }
        //     set { ParserType.ParsedOutputList = value; }
        // }
        // public List<string> ParsedOutput
        // {
        //     get { return ParserType.ParsedOutput; }
        //     set { ParserType.ParsedOutput = value; }
        // }
        public List<string[]> ParsedOutput
        {
            get { return ParserType.ParsedOutput; }
            set { ParserType.ParsedOutput = value; }
        }
    }
}
