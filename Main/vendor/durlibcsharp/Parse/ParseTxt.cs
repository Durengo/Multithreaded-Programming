namespace DurlibCS.Parse
{
    public class ParseTxt : Parseable
    {
        private string filename = "";
        private string filepath = "";
        private string output = "";
        // private ConcurrentQueue<string[]> parsedOutputList;
        // private List<string> parsedOutput;
        private List<string[]> parsedOutput;
        private DOCTYPE type = DOCTYPE.TXT;
        public Exception EXCPT = null;
        //public static Mutex mutex = new Mutex();

        public ParseTxt(string title)
        {
            try
            {
                var file = File.Open(title, FileMode.Open);
                file.Close();
                filename = title;
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
        public void Parse(string parseSettings)
        {
            if (parsedOutput == null)
            {
                parsedOutput = new List<string[]>();
            }
            else
            {
                parsedOutput.Clear();
            }
            var fileLines = File.ReadAllLines(filename);
            var file = new System.IO.StreamReader(filename);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] word = line.Split(parseSettings);
                parsedOutput.Add(word);
            }

        }
        // public void Parse(string parseSettings)
        // {
        //     if (parsedOutputList == null)
        //     {
        //         parsedOutputList = new ConcurrentQueue<string[]>();
        //     }
        //     else
        //     {
        //         parsedOutputList.Clear();
        //     }
        //     //string line;
        //     //var file = new System.IO.StreamReader(filename);
        //     //var fileLines = File.ReadAllLines(filename);

        //     // Parallel.ForEach(fileLines, line =>
        //     // {
        //     //     parsing(new string(line), parseSettings, parsedOutputList);
        //     // });


        //     var lines = File.ReadAllLines(filename);
        //     var threads = new Thread[Environment.ProcessorCount];

        //     using (var resetEvent = new ManualResetEvent(false))
        //     {
        //         int threadsCount = threads.Length;
        //         // ThreadPool.SetMinThreads(Environment.ProcessorCount, Environment.ProcessorCount);
        //         // ThreadPool.SetMaxThreads(Environment.ProcessorCount * 2, Environment.ProcessorCount * 2);

        //         //for (int i = 0; i < threads.Length; i++)
        //         for (int i = 0; i < threadsCount; i++)
        //         {
        //             // ThreadPool.QueueUserWorkItem(state => 
        //             // {
        //             //     string[] words = lines[(int) state].Split(parseSettings);
        //             //     parsedOutputList.Enqueue(words);

        //             //     if (Interlocked.Increment(ref i) == lines.Length)
        //             //     {
        //             //         resetEvent.Set();
        //             //     }
        //             // }, i);

        //             int threadIndex = i;
        //             threads[i] = new Thread(() => parsing(lines, parseSettings, threadIndex, threads.Length, resetEvent));
        //             threads[i].Start();
        //         }

        //         resetEvent.WaitOne(1000);

        //         foreach (var t in threads)
        //         {
        //             t.Join();
        //         }
        //     }

        //     //file.Close();
        // }
        // private void parsing(string[] lines, string param, int startIndex, int stepSize, ManualResetEvent resetEvent)
        // {
        //     int finishedThreads = 0;

        //     for (int i = startIndex; i < lines.Length; i += stepSize)
        //     {
        //         string[] words = lines[i].Split(param);
        //         parsedOutputList.Enqueue(words);
        //     }

        //     // if (Interlocked.Decrement(ref stepSize) == 0)
        //     // {
        //     //     resetEvent.Set();
        //     // }
        //     if (Interlocked.Increment(ref finishedThreads) == stepSize)
        //     {
        //         resetEvent.Set();
        //     }
        //     // using (var mutex = new Mutex())
        //     // {
        //     //     mutex.WaitOne();
        //     //     try
        //     //     {
        //     //         string words = line;
        //     //         outputL.Add(words);
        //     //     }
        //     //     finally
        //     //     {
        //     //         mutex.ReleaseMutex();
        //     //     }
        //     // }
        //     // string[] words = line.Split(param);
        //     // mutex.WaitOne();
        //     // parsedOutput.Add(words);
        //     // mutex.ReleaseMutex();
        // }
        // public void Parse(string parseSettings)
        // {
        //     if (parsedOutput == null)
        //     {
        //         parsedOutput = new List<string[]>();
        //     }
        //     else
        //     {
        //         parsedOutput.Clear();
        //     }
        //     string line;
        //     var file = new System.IO.StreamReader(filename);
        //     var fileLines = File.ReadAllLines(filename);
        //     Parallel.ForEach(fileLines, line =>
        //     {
        //         parsing(new string(line), parseSettings, parsedOutput);
        //     });
        //     // List<Thread> threads = new List<Thread>();
        //     // while ((line = file.ReadLine()) != null)
        //     // {
        //     //     //Thread thread = new Thread(() => ParseLine(line, parseSettings, buffer));
        //     //     Thread thread = new Thread(() => parsing(new string(line), parseSettings, parsedOutput));
        //     //     // Thread thread = new Thread(() =>
        //     //     // {
        //     //     //     string newline = line;
        //     //     //     mutex.WaitOne();
        //     //     //     string[] words = newline.Split(parseSettings);
        //     //     //     parsedOutput.Add(words);
        //     //     //     mutex.ReleaseMutex();
        //     //     // });
        //     //     thread.Start();
        //     //     threads.Add(thread);

        //     //     //string[] words = line.Split(parseSettings);
        //     //     //parsedOutput.Add(words);
        //     // }
        //     // foreach (Thread t in threads)
        //     // {
        //     //     t.Join();
        //     // }
        //     file.Close();
        // }
        // private void parsing(string line, string param, List<String[]> outputL)
        // {
        //     using (var mutex = new Mutex())
        //     {
        //         mutex.WaitOne();
        //         try
        //         {
        //             string[] words = line.Split(param);
        //             outputL.Add(words);
        //         }
        //         finally
        //         {
        //             mutex.ReleaseMutex();
        //         }
        //     }
        //     // string[] words = line.Split(param);
        //     // mutex.WaitOne();
        //     // parsedOutput.Add(words);
        //     // mutex.ReleaseMutex();

        //     // private void ParseLine(string line, string param, string[] buffer)
        //     // {
        //     //     mutex.WaitOne();
        //     //     if (line == null)
        //     //     {
        //     //         mutex.ReleaseMutex();
        //     //         return;
        //     //     }
        //     //     buffer = line.Split(param);
        //     //     parsedOutput.Add(buffer);
        //     //     mutex.ReleaseMutex();
        // }
        public void Parse(string[] parseSettings)
        {
            // string line;
            // var file = new System.IO.StreamReader(filename);
            // while ((line = file.ReadLine()) != null)
            // {
            //     //parsedOutput = line.Split(parseSettings[0]);
            //     string[] words = line.Split(parseSettings[0]);
            //     parsedOutput.Add(words);
            // }
            // file.Close();
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
        // public ConcurrentQueue<string[]> ParsedOutputList
        // {
        //     get { return parsedOutputList; }
        //     set { parsedOutputList = value; }
        // }
        // public List<string> ParsedOutput
        // {
        //     get { return parsedOutput; }
        //     set { parsedOutput = value; }
        // }
        public List<string[]> ParsedOutput
        {
            get { return parsedOutput; }
            set { parsedOutput = value; }
        }
    }
}