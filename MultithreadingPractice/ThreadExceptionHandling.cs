using System;
using System.Threading;

namespace MultithreadingPractice
{
    public class ThreadExceptionHandling
    {
        public static void Run()
        {
            Thread t = new Thread(new ThreadStart(InteruptableThread));
            t.Start();
            Thread.Sleep(1000);
            t.Abort();
            Console.ReadLine();
        }

        public static void InteruptableThread()
        {
            Console.WriteLine("Starting execution of thread");

            try
            {
                Thread.Sleep(10000);
                Console.WriteLine("Thread finished waiting");
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Caught ThreadInterruptException");
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Caught ThreadAbortException");
            }
            finally
            {
                Console.WriteLine("Thread finally");
            }

            Console.WriteLine("Finished normal execution of thread");
        }
    }
}
