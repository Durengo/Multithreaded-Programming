using DurlibCS.Math;
using DurlibCS.Log;
using System;
namespace MatrixUnitTest
{
    [TestClass]
    public class MatrixMultithreadingTest
    {
        [TestMethod]
        public void MULTITHREADED_MULTIPLICATION_TIME()
        {
            Random rnd = new Random();
            int n = 100;
            int m = 100;
            int k = 100;

            Matrix A = new Matrix(n, m).RandomValues();
            Matrix B = new Matrix(m, k).RandomValues();

            //DurLog.LogL(LogErrorLevel.INFO, "MATRIX A:");
            //A.Print();
            //DurLog.LogL(LogErrorLevel.INFO, "MATRIX B:");
            //B.Print();
            //DurLog.LogL(LogErrorLevel.INFO, "A * B:");
            Matrix C = A * B;
            //C.Print();

            Assert.IsTrue(true);
        }
        [TestMethod]
        public void MULTITHREADED_MULTIPLICATION()
        {
            int N = 4;
            int M = 4;
            int K = 3;

            Matrix EXPECTED = new Matrix(N, K);
            double[,] EXPECTEDMATRIX =
                {{ 602241, 13020, 7988 },
                { 1124457, 71926, 87098 },
                { 136173, 33062, 4966 },
                { 6306383, 381265, 67887 }};
            EXPECTED.MatrixArray = EXPECTEDMATRIX;

            Matrix MatA = new Matrix(N, M);
            double[,] MatrixA =
                {{ 54, 84, 34, 17 },
                { 874, 98, 14, 5 },
                { 3, 8, 10, 79 },
                { 99, 813, 156, 871 }
            };
            MatA.MatrixArray = MatrixA;

            Matrix MatB = new Matrix(N, K);
            double[,] MatrixB =
                {{ 542, 78, 98 },
                { 6574, 15, 7 },
                { 98, 16, 35 },
                { 1025, 412, 54 }
            };
            MatB.MatrixArray = MatrixB;

            Matrix ACTUAL = new Matrix(N, K);
            ACTUAL.MatrixArray = (MatA * MatB).MatrixArray;

            DurLog.LogL("EXPECTED:");
            EXPECTED.Print();
            DurLog.LogL("ACTUAL:");
            ACTUAL.Print();

            Assert.IsTrue(EXPECTED == ACTUAL);
        }
        [TestMethod]
        public void MULTITHREADED_ADDITION()
        {
            int N = 3;
            int M = 3;
            int K = 3;

            Matrix EXPECTED = new Matrix(N, K);
            double[,] EXPECTEDMATRIX =
                {{ 985, 656, 349 },
                { 70, 51, 12 },
                { 1412, 83, 6 }};
            EXPECTED.MatrixArray = EXPECTEDMATRIX;

            Matrix MatA = new Matrix(N, M);
            double[,] MatrixA =
                {{ 984, 654, 2 },
                { 13, 45, 4 },
                { 58, 78, 2 }};
            MatA.MatrixArray = MatrixA;

            Matrix MatB = new Matrix(N, K);
            double[,] MatrixB =
                {{ 1, 2, 347 },
                { 57, 6, 8 },
                { 1354, 5, 4}};
            MatB.MatrixArray = MatrixB;

            Matrix ACTUAL = new Matrix(N, K);
            ACTUAL.MatrixArray = (MatA + MatB).MatrixArray;

            DurLog.LogL("EXPECTED:");
            EXPECTED.Print();
            DurLog.LogL("ACTUAL:");
            ACTUAL.Print();

            Assert.IsTrue(EXPECTED == ACTUAL);
        }
        [TestMethod]
        public void MULTITHREADED_SUBTRACTION()
        {
            int N = 3;
            int M = 3;
            int K = 3;

            Matrix EXPECTED = new Matrix(N, K);
            double[,] EXPECTEDMATRIX =
                {{ 983, 652, -345 },
                { -44, 39, -4 },
                { -1296, 73, -2 }};
            EXPECTED.MatrixArray = EXPECTEDMATRIX;

            Matrix MatA = new Matrix(N, M);
            double[,] MatrixA =
                {{ 984, 654, 2 },
                { 13, 45, 4 },
                { 58, 78, 2 }};
            MatA.MatrixArray = MatrixA;

            Matrix MatB = new Matrix(N, K);
            double[,] MatrixB =
                {{ 1, 2, 347 },
                { 57, 6, 8 },
                { 1354, 5, 4}};
            MatB.MatrixArray = MatrixB;

            Matrix ACTUAL = new Matrix(N, K);
            ACTUAL.MatrixArray = (MatA - MatB).MatrixArray;

            DurLog.LogL("EXPECTED:");
            EXPECTED.Print();
            DurLog.LogL("ACTUAL:");
            ACTUAL.Print();

            Assert.IsTrue(EXPECTED == ACTUAL);
        }
        [TestMethod]
        public void NON_MULTITHREADED_MULTIPLICATION()
        {
            Matrix.MULTIRHEADING_ENABLED = false;

            int N = 4;
            int M = 4;
            int K = 3;

            Matrix EXPECTED = new Matrix(N, K);
            double[,] EXPECTEDMATRIX =
                {{ 602241, 13020, 7988 },
                { 1124457, 71926, 87098 },
                { 136173, 33062, 4966 },
                { 6306383, 381265, 67887 }};
            EXPECTED.MatrixArray = EXPECTEDMATRIX;

            Matrix MatA = new Matrix(N, M);
            double[,] MatrixA =
                {{ 54, 84, 34, 17 },
                { 874, 98, 14, 5 },
                { 3, 8, 10, 79 },
                { 99, 813, 156, 871 }
            };
            MatA.MatrixArray = MatrixA;

            Matrix MatB = new Matrix(N, K);
            double[,] MatrixB =
                {{ 542, 78, 98 },
                { 6574, 15, 7 },
                { 98, 16, 35 },
                { 1025, 412, 54 }
            };
            MatB.MatrixArray = MatrixB;

            Matrix ACTUAL = new Matrix(N, K);
            ACTUAL.MatrixArray = (MatA * MatB).MatrixArray;

            DurLog.LogL("EXPECTED:");
            EXPECTED.Print();
            DurLog.LogL("ACTUAL:");
            ACTUAL.Print();

            Assert.IsTrue(EXPECTED == ACTUAL);
        }
        [TestMethod]
        public void NON_MULTITHREADED_ADDITION()
        {
            Matrix.MULTIRHEADING_ENABLED = false;

            int N = 3;
            int M = 3;
            int K = 3;

            Matrix EXPECTED = new Matrix(N, K);
            double[,] EXPECTEDMATRIX =
                {{ 985, 656, 349 },
                { 70, 51, 12 },
                { 1412, 83, 6 }};
            EXPECTED.MatrixArray = EXPECTEDMATRIX;

            Matrix MatA = new Matrix(N, M);
            double[,] MatrixA =
                {{ 984, 654, 2 },
                { 13, 45, 4 },
                { 58, 78, 2 }};
            MatA.MatrixArray = MatrixA;

            Matrix MatB = new Matrix(N, K);
            double[,] MatrixB =
                {{ 1, 2, 347 },
                { 57, 6, 8 },
                { 1354, 5, 4}};
            MatB.MatrixArray = MatrixB;

            Matrix ACTUAL = new Matrix(N, K);
            ACTUAL.MatrixArray = (MatA + MatB).MatrixArray;

            DurLog.LogL("EXPECTED:");
            EXPECTED.Print();
            DurLog.LogL("ACTUAL:");
            ACTUAL.Print();

            Assert.IsTrue(EXPECTED == ACTUAL);
        }
        [TestMethod]
        public void NON_MULTITHREADED_SUBTRACTION()
        {
            Matrix.MULTIRHEADING_ENABLED = false;

            int N = 3;
            int M = 3;
            int K = 3;

            Matrix EXPECTED = new Matrix(N, K);
            double[,] EXPECTEDMATRIX =
                {{ 983, 652, -345 },
                { -44, 39, -4 },
                { -1296, 73, -2 }};
            EXPECTED.MatrixArray = EXPECTEDMATRIX;

            Matrix MatA = new Matrix(N, M);
            double[,] MatrixA =
                {{ 984, 654, 2 },
                { 13, 45, 4 },
                { 58, 78, 2 }};
            MatA.MatrixArray = MatrixA;

            Matrix MatB = new Matrix(N, K);
            double[,] MatrixB =
                {{ 1, 2, 347 },
                { 57, 6, 8 },
                { 1354, 5, 4}};
            MatB.MatrixArray = MatrixB;

            Matrix ACTUAL = new Matrix(N, K);
            ACTUAL.MatrixArray = (MatA - MatB).MatrixArray;

            DurLog.LogL("EXPECTED:");
            EXPECTED.Print();
            DurLog.LogL("ACTUAL:");
            ACTUAL.Print();

            Assert.IsTrue(EXPECTED == ACTUAL);
        }
    }
}