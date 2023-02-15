// https://www.tutorialspoint.com/csharp/csharp_multithreading.htm
using System;
using System.Threading;

using durlibcsharp;
using DurlibMathDefinition;
using source.Math.Matrix;
namespace MultithreadedProgramming;
class Program
{
    public static void ThreadStarter()
    {
        try
        {
            Console.WriteLine("Thread Activated!");
            Console.WriteLine("Thread Will Sleep!");
            Thread.Sleep(1000);
            Console.WriteLine("Thread Will Awake!");

            Console.WriteLine("Begin countdown!");
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + 1);
            }
        }
        catch (ThreadAbortException e)
        {
            Console.WriteLine("Thread Abort Exception");
        }
        finally
        {
            Console.WriteLine("Couldn't catch the Thread Exception");
        }

    }
    static void Main(string[] args)
    {
        SquareMatrix mat = new SquareMatrix(new float[]{1.3f, 2.2f, 5.1f, 3.5f}, new float[]{0.5f, 1.5f, 3.0f, 1.7f});
        //mat.Print();
        mat.PrintSquare();
        // Console.WriteLine($"Hello, World!");
        // ThreadStart th = new ThreadStart(ThreadStarter);
        // Console.WriteLine("Seperating threads!");

        // Console.WriteLine("Activating Thread Process");
        // Thread childTh = new Thread(th);
        // childTh.Start();
        // Console.WriteLine("End Of Thread Activation Process");

        // Thread.Sleep(2000);

        // Console.WriteLine("Abortion will happen!");
        // childTh.Interrupt();

        Console.ReadKey();
    }
}
