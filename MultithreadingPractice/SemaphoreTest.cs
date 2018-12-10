using System;
using System.Threading;

namespace MultithreadingPractice
{
    public class SemaphoreTest
    {
        private static Semaphore _pool;
        private static int _padding;

        public static void Run()
        {
            _pool = new Semaphore(0, 3);

            for (int i = 0; i <= 5; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Worker));
                t.Start(i);
            }

            Thread.Sleep(500);

            Console.WriteLine("Main threa calls Release(3)");
            _pool.Release(3);

            Console.WriteLine("Main thread exits");
            Console.ReadLine();
        }

        private static void Worker(object num)
        {
            Console.WriteLine($"Thread {num} begins and waits for the semaphore");
            _pool.WaitOne();

            int padding = Interlocked.Add(ref _padding, 100);

            Console.WriteLine($"Thread {num} enters the semaphore");

            Thread.Sleep(1000 + _padding);

            Console.WriteLine($"Thread {num} releases the semaphore");
            Console.WriteLine($"Thread {num} previous semaphore count {_pool.Release()}");
        }

    }
}
