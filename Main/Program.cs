using System;
using System.Threading;

using DurlibCS.Log;
using DurlibCS.Math;
using DurlibCS.Input;
using DurlibCS.Parse;

namespace MultithreadedProgramming;
class Program
{
    public static void GenerateMatricesInFile()
    {
        int n, m;
        Random rnd = new Random();
        {
            rnd.Next(1, 10);
            n = rnd.Next(1, 10);
            m = rnd.Next(1, 10);

            Matrix A = new Matrix(n, m).RandomValues();
            Logger MatA = new Logger(new SimpleTextFileLog("MatrixA.txt", false, true));
            //Logger MatA = new Logger(new JsonLog("MatrixA.json"));
            MatA.LogL($"{A.Row},{A.Column}");
            MatA.Log(A);
        }
        {
            rnd.Next(1, 10);
            n = rnd.Next(1, 10);
            m = rnd.Next(1, 10);

            Matrix B = new Matrix(n, m).RandomValues();
            Logger MatB = new Logger(new SimpleTextFileLog("MatrixB.txt", false, true));
            //Logger MatB = new Logger(new JsonLog("MatrixB.json"));
            MatB.LogL($"{B.Row},{B.Column}");
            MatB.Log(B);
        }
    }
    public static void parse()
    {
        Parser matA = new Parser(new ParseTxt("MatrixA.txt"));
        matA.Parse("\n");
        //DurLog.LogL(matA.ParsedOutput[0][0].Split(",")[1]);
        string[] rowColumns = matA.ParsedOutput[0][0].Split(",");
        int rows = InputValidation.GIBI(rowColumns[0]);
        int columns = InputValidation.GIBI(rowColumns[1]);
        DurLog.LogL($"rows: {rows}, columns: {columns}");
        Matrix MatA = new Matrix(rows, columns);
        // MatA.Row = rows;
        // MatA.Column = columns;
        for (int i = 0; i < MatA.Row; i++)
        {
            for (int j = 0; j < MatA.Column; j++)
            {
                MatA[i, j] = InputValidation.GIBD(matA.ParsedOutput[i + 1][0].Split(" ")[j]);
            }
        }
        MatA.Print();
        // foreach (var text in matA.ParsedOutput)
        // {
        //         // DurLog.LogL(LogErrorLevel.INFO, text);

        //     foreach(var item in text)
        //     {
        //         DurLog.LogL(LogErrorLevel.INFO, item);
        //     }
        // }
    }
    static void Main(string[] args)
    {
        {
            DurLog.LogL(LogErrorLevel.ERROR, "MULTIPLICATION");

            Random rnd = new Random();

            int n = rnd.Next(1, 10);
            int m = rnd.Next(1, 10);
            int k = rnd.Next(1, 10);

            Matrix A = new Matrix(n, m).RandomValues();
            Matrix B = new Matrix(m, k).RandomValues();

            DurLog.LogL(LogErrorLevel.INFO, "MATRIX A:");
            A.Print();
            DurLog.LogL(LogErrorLevel.INFO, "MATRIX B:");
            B.Print();
            DurLog.LogL(LogErrorLevel.INFO, "A * B:");
            Matrix C = A * B;
            C.Print();
        }
        {
            DurLog.LogL(LogErrorLevel.ERROR, "MULTIPLICATION 3X3");

            int n = 3;
            int m = 3;
            int k = 3;

            Matrix A = new Matrix(n, m).RandomValues();
            Matrix B = new Matrix(m, k).RandomValues();

            DurLog.LogL(LogErrorLevel.INFO, "MATRIX A:");
            A.Print();
            DurLog.LogL(LogErrorLevel.INFO, "MATRIX B:");
            B.Print();
            DurLog.LogL(LogErrorLevel.INFO, "A * B:");
            Matrix C = A * B;
            C.Print();
            DurLog.LogL(LogErrorLevel.INFO, "B * A:");
            Matrix D = B * A;
            D.Print();
        }
        {
            DurLog.LogL(LogErrorLevel.ERROR, "ADDITION & SUBTRACTION");

            int n = 3;
            int m = 3;
            int k = 3;

            Matrix A = new Matrix(n, m).RandomValues();
            Matrix B = new Matrix(m, k).RandomValues();

            DurLog.LogL(LogErrorLevel.INFO, "MATRIX A:");
            A.Print();
            DurLog.LogL(LogErrorLevel.INFO, "MATRIX B:");
            B.Print();
            DurLog.LogL(LogErrorLevel.INFO, "A + B:");
            Matrix C = A + B;
            C.Print();
            DurLog.LogL(LogErrorLevel.INFO, "A - B:");
            Matrix D = A - B;
            D.Print();
            DurLog.LogL(LogErrorLevel.INFO, "B - A:");
            Matrix E = B - A;
            E.Print();
        }

        // GenerateMatricesInFile();
        // parse();

        Console.ReadKey();
    }
}
