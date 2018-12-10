using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MultithreadingPractice
{
    public class InterlockTest
    {
        public static int count = 0;

        public static void Run()
        {
            int threadCount = 100;
            int loops = 1000;
            int loopCount = 50;
            Stopwatch sw = new Stopwatch();
            long nonInterlockedMilliseconds = 0;
            long interlockedMilliseconds = 0;

            Console.WriteLine("Race condition counts");

            for (int i = 0; i < loopCount; i++)
            {
                count = 0;
                List<Thread> _pool = new List<Thread>();

                sw.Start();

                for (int j = 0; j < threadCount; j++)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(IncrementCount));
                    t.Start(loops);
                    _pool.Add(t);
                }

                foreach (Thread t in _pool)
                {
                    t.Join();
                }

                sw.Stop();
                nonInterlockedMilliseconds += sw.ElapsedMilliseconds;
                sw.Reset();
                Console.WriteLine($"{count}");
            }

            Console.WriteLine("\nInterlocked counts");

            for (int i = 0; i < loopCount; i++)
            {
                count = 0;
                List<Thread> _pool = new List<Thread>();

                sw.Start();

                for (int j = 0; j < threadCount; j++)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(IncrementCountInterlocked));
                    t.Start(loops);
                    _pool.Add(t);
                }

                foreach (Thread t in _pool)
                {
                    t.Join();
                }

                sw.Stop();
                interlockedMilliseconds += sw.ElapsedMilliseconds;
                sw.Reset();
                Console.WriteLine($"{count}");
            }

            Console.WriteLine($"Average race condition time: {nonInterlockedMilliseconds / loopCount}");
            Console.WriteLine($"Average interlocked time: {interlockedMilliseconds / loopCount}");
            Console.ReadLine();
        }

        public static void IncrementCount(object loops)
        {
            for (int i = 0; i < (int)loops; i++)
                count++;
        }

        public static void IncrementCountInterlocked(object loops)
        {
            for (int i = 0; i < (int)loops; i++)
                Interlocked.Increment(ref count);
        }
    }
}
