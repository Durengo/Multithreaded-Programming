using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace durlibcsharp
{
    public class Parser
    {
        private string Filename = "";
        private string Filepath = "";
        private string Output = "";

        private Parseable ParserType;

        public Parser(Parseable parserType)
        {
            if (ParserType == null)
            {
                throw new ArgumentNullException();
            }
            ParserType = parserType;
        }
    }
}
