using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingPractice
{
    public class ThreadPriorityTest
    {
        public static void Run()
        {
            Thread t1 = new Thread(new ThreadStart(PrintThreadName));
            t1.Name = "Thread 1: Lowest Priority";
            t1.Priority = ThreadPriority.Lowest;

            Thread t2 = new Thread(new ThreadStart(PrintThreadName));
            t2.Name = "Thread 2: Bellow Normal Priority";
            t2.Priority = ThreadPriority.BelowNormal;

            Thread t3 = new Thread(new ThreadStart(PrintThreadName));
            t3.Name = "Thread 3: Normal Priority";
            t3.Priority = ThreadPriority.Normal;

            Thread t4 = new Thread(new ThreadStart(PrintThreadName));
            t4.Name = "Thread 4: Above Normal Priority";
            t4.Priority = ThreadPriority.AboveNormal;

            Thread t5 = new Thread(new ThreadStart(PrintThreadName));
            t5.Name = "Thread 5: Highest Priority";
            t5.Priority = ThreadPriority.Highest;

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            Console.ReadLine();
        }

        public static void PrintThreadName()
        {
            Thread.Sleep(5000);
            Console.WriteLine($"{Thread.CurrentThread.Name}");
        }
    }
}
