using DurlibCS.Log;

/*
This class is a simple matrix class.
It can perform basic operations on matrices.
It can also perform multithreaded operations on matrices (Multiplication, Addition, Subtraction, Equality, Inequality).
*/
namespace DurlibCS.Math
{
    public struct Matrix
    {
        public static bool MULTIRHEADING_ENABLED = true;
        public static bool MULTIRHEADING_MULTIPLICATION = true;
        public static bool MULTIRHEADING_ADDITION = true;
        public static bool MULTIRHEADING_SUBTRACTION = true;
        public static bool MULTIRHEADING_EQUALITY = true;
        public static bool MULTIRHEADING_NOTEQUALITY = true;
        private int row;
        private int column;
        private double[,] matrixArray;
        public static Mutex mutex = new Mutex();
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int Column
        {
            get { return column; }
            set { column = value; }
        }
        public double[,] MatrixArray
        {
            get { return matrixArray; }
            set { matrixArray = value; }
        }
        public Matrix(int rows, int columns)
        {
            row = rows;
            column = columns;
            matrixArray = new double[row, column];
        }
        public double[] GetColumn(int i)
        {
            double[] res = new double[Row];
            for (int j = 0; j < Row; j++)
                res[j] = matrixArray[j, i];
            return res;
        }
        public double[] GetRow(int i)
        {
            double[] res = new double[Column];
            for (int j = 0; j < Column; j++)
                res[j] = matrixArray[i, j];
            return res;
        }
        public Matrix RandomValues()
        {
            Random rnd = new Random();
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Column; j++)
                    matrixArray[i, j] = rnd.Next(1, 100);
            return this;
        }
        public void Print()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    DurLog.Log(matrixArray[i, j] + " ");
                }
                DurLog.LogL("");
            }
        }
        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    text += matrixArray[i, j] + " ";
                }
                text += "\n";
            }
            return text;
        }
        public double this[int i, int j]
        {
            get { return matrixArray[i, j]; }
            set { matrixArray[i, j] = value; }
        }
        public static Matrix operator +(Matrix lhs, Matrix rhs)
        {
            if (MULTIRHEADING_ENABLED && MULTIRHEADING_ADDITION)
            {
                if (lhs.Row != rhs.Row || lhs.Column != rhs.Column)
                {
                    throw new Exception("Matrix sizes do not match.");
                }
                List<Thread> threads = new List<Thread>();
                Matrix result = new Matrix(lhs.Row, lhs.Column);
                for (int i = 0; i < lhs.Row; i++)
                {
                    int tempi = i;
                    Thread thread = new Thread(() => VectorAddition(tempi, lhs, rhs, result));
                    thread.Start();
                    threads.Add(thread);
                }
                foreach (Thread t in threads)
                {
                    t.Join();
                }
                return result;
            }
            else if (!MULTIRHEADING_ENABLED || !MULTIRHEADING_ADDITION)
            {
                if (lhs.Row != rhs.Row || lhs.Column != rhs.Column)
                {
                    throw new Exception("Matrix sizes do not match.");
                }
                Matrix result = new Matrix(lhs.Row, lhs.Column);
                for (int i = 0; i < lhs.Row; i++)
                {
                    for (int j = 0; j < lhs.Column; j++)
                    {
                        result[i, j] = lhs[i, j] + rhs[i, j];
                    }
                }
                return result;
            }
            else
            {
                throw new OutOfMemoryException();
            }
        }
        public static void VectorAddition(int tmpi, Matrix lhs, Matrix rhs, Matrix result)
        {
            mutex.WaitOne();
            int i = tmpi;

            for (int j = 0; j < lhs.Row; j++)
            {
                result[i, j] = lhs[i, j] + rhs[i, j];
                //DurLog.LogL(LogErrorLevel.WARN, $"{result[i, k]}");
            }
            mutex.ReleaseMutex();
        }
        public static Matrix operator -(Matrix lhs, Matrix rhs)
        {
            if (lhs.Row != rhs.Row || lhs.Column != rhs.Column)
            {
                throw new Exception("Matrix sizes do not match.");
            }
            else if (MULTIRHEADING_ENABLED && MULTIRHEADING_SUBTRACTION)
            {
                List<Thread> threads = new List<Thread>();
                Matrix result = new Matrix(lhs.Row, lhs.Column);
                for (int i = 0; i < lhs.Row; i++)
                {
                    int tempi = i;
                    Thread thread = new Thread(() => VectorSubtract(tempi, lhs, rhs, result));
                    thread.Start();
                    threads.Add(thread);
                }
                foreach (Thread t in threads)
                {
                    t.Join();
                }
                return result;
            }
            if (!MULTIRHEADING_ENABLED || !MULTIRHEADING_SUBTRACTION)
            {
                Matrix result = new Matrix(lhs.Row, lhs.Column);
                for (int i = 0; i < lhs.Row; i++)
                {
                    for (int j = 0; j < lhs.Column; j++)
                    {
                        result[i, j] = lhs[i, j] - rhs[i, j];
                    }
                }
                return result;
            }
            else
            {
                throw new OutOfMemoryException();
            }
        }
        public static void VectorSubtract(int tmpi, Matrix lhs, Matrix rhs, Matrix result)
        {
            mutex.WaitOne();
            int i = tmpi;

            for (int j = 0; j < lhs.Row; j++)
            {
                result[i, j] = lhs[i, j] - rhs[i, j];
            }
            mutex.ReleaseMutex();
        }
        public static bool operator ==(Matrix lhs, Matrix rhs)
        {
            if (lhs.Row != rhs.Row || lhs.Column != rhs.Column)
            {
                return false;
            }
            if (MULTIRHEADING_ENABLED && MULTIRHEADING_EQUALITY)
            {
                List<Thread> threads = new List<Thread>();
                bool result = new bool();
                result = true;
                while (result)
                {
                    for (int i = 0; i < lhs.Column; i++)
                    {
                        int tempi = i;
                        Thread thread = new Thread(() => VectorEqual(tempi, lhs, rhs, ref result));
                        thread.Start();
                        threads.Add(thread);
                    }
                    break;
                }
                foreach (Thread t in threads)
                {
                    t.Join();
                }
                return result;
            }
            else if (!MULTIRHEADING_ENABLED || !MULTIRHEADING_EQUALITY)
            {
                bool result = true;
                while (result)
                {
                    for (int i = 0; i < lhs.Row - 1; i++)
                    {
                        for (int j = 0; j < rhs.Column - 1; j++)
                        {
                            if (lhs.MatrixArray[i, j] == rhs.MatrixArray[i, j])
                            {
                                result = true;
                                break;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                    }
                    break;
                }
                return result;
            }
            else
            {
                throw new OutOfMemoryException();
            }
        }
        public static void VectorEqual(int tmpi, Matrix lhs, Matrix rhs, ref bool result)
        {
            mutex.WaitOne();
            int i = tmpi;

            for (int j = 0; j < lhs.Column; j++)
            {
                if (lhs[i, j] == rhs[i, j])
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            mutex.ReleaseMutex();
        }
        public static bool operator !=(Matrix lhs, Matrix rhs)
        {
            if (lhs.Row != rhs.Row || lhs.Column != rhs.Column)
            {
                return true;
            }
            if (MULTIRHEADING_ENABLED && MULTIRHEADING_NOTEQUALITY)
            {
                List<Thread> threads = new List<Thread>();
                bool result = false;
                while (!result)
                {
                    for (int i = 0; i < lhs.Row - 1; i++)
                    {
                        int tempi = i;
                        Thread thread = new Thread(() => VectorNotEqual(tempi, lhs, rhs, ref result));
                        thread.Start();
                        threads.Add(thread);
                    }
                    break;
                }
                foreach (Thread t in threads)
                {
                    t.Join();
                }
                return result;
            }
            else if (!MULTIRHEADING_ENABLED || !MULTIRHEADING_NOTEQUALITY)
            {
                bool result = false;
                while (!result)
                {
                    for (int i = 0; i < lhs.Row - 1; i++)
                    {
                        for (int j = 0; j < rhs.Column - 1; j++)
                        {
                            if (lhs.MatrixArray[i, j] == rhs.MatrixArray[i, j])
                            {
                                result = true;
                                break;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                    }
                    break;
                }
                return result;
            }
            else
            {
                throw new OutOfMemoryException();
            }
        }
        public static void VectorNotEqual(int tmpi, Matrix lhs, Matrix rhs, ref bool result)
        {
            mutex.WaitOne();
            int i = tmpi;

            for (int j = 0; j < lhs.Row; j++)
            {
                if (lhs[i, j] == rhs[i, j])
                {
                    result = false;
                }
                else
                {
                    result = true;
                    break;
                }
            }

            mutex.ReleaseMutex();
        }
        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
            if (lhs.Column != rhs.Row)
            {
                throw new Exception($"Matrix sizes do not match. ( {lhs.Column}<-COLUMN!=ROW->{rhs.Row} )");
            }
            if (MULTIRHEADING_ENABLED && MULTIRHEADING_MULTIPLICATION)
            {
                Matrix result = new Matrix(lhs.Row, rhs.Column);
                List<Thread> threads = new List<Thread>();
                //int count = 1;
                for (int i = 0; i < lhs.Row; i++)
                {
                    for (int j = 0; j < rhs.Column; j++)
                    {
                        int tempi = i;
                        int tempj = j;
                        Thread thread = new Thread(() => VectorMult(tempi, tempj, lhs, rhs, result));
                        // thread.Name = Convert.ToString(count);
                        // count++;
                        thread.Start();
                        threads.Add(thread);
                    }
                }
                foreach (Thread t in threads)
                {
                    //DurLog.LogL(t.Name);
                    t.Join();
                }
                return result;
            }
            else if (!MULTIRHEADING_ENABLED || !MULTIRHEADING_MULTIPLICATION)
            {
                Matrix result = new Matrix(lhs.Row, rhs.Column);
                for (int i = 0; i < lhs.Row; i++)
                {
                    for (int j = 0; j < rhs.Column; j++)
                    {
                        double[] x = lhs.GetRow(i);
                        double[] y = rhs.GetColumn(j);

                        for (int k = 0; k < x.Length; k++)
                        {
                            result[i, j] += x[k] * y[k];
                        }
                    }
                }
                return result;
            }
            else
            {
                throw new OutOfMemoryException();
            }
        }
        public static void VectorMult(int tmpi, int tmpj, Matrix lhs, Matrix rhs, Matrix result)
        {
            //DurLog.LogL("thread start?");
            mutex.WaitOne();
            int i = tmpi;
            int j = tmpj;
            double[] x = lhs.GetRow(i);
            double[] y = rhs.GetColumn(j);

            for (int k = 0; k < x.Length; k++)
            {
                //result[i, j] += x[k] * y[k];
                result[i, j] = result[i, j] + (x[k] * y[k]);
            }
            mutex.ReleaseMutex();
            //DurLog.LogL("thread end?");
        }
    }
}