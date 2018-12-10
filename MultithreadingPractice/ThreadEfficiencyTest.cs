using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MultithreadingPractice
{
    public class ThreadEfficiencyTest
    {
        public static void Run()
        {
            int threadCount = 5;
            List<Thread> _pool = new List<Thread>();

            Stopwatch sw = new Stopwatch();

            Thread.Sleep(1000);

            long creationTicks = 0;

            Process proc = Process.GetCurrentProcess();
            Console.WriteLine(proc.WorkingSet64 + "\n");

            for (int i = 0; i < threadCount; i++)
            {
                sw.Start();

                Thread thread = new Thread(new ThreadStart(WaitThread));
                _pool.Add(thread);

                sw.Stop();
                //Console.WriteLine(sw.ElapsedTicks);
                creationTicks += sw.ElapsedMilliseconds;
                sw.Reset();
            }

            proc = Process.GetCurrentProcess();
            Console.WriteLine(proc.WorkingSet64 + "\n");

            Console.WriteLine($"Total creation time: {creationTicks} ticks");
            Console.WriteLine($"Average creation time: {creationTicks / threadCount} ticks\n");

            long startTicks = 0;

            foreach (Thread t in _pool)
            {
                sw.Start();

                t.Start();

                sw.Stop();
                //Console.WriteLine(sw.ElapsedTicks);
                startTicks += sw.ElapsedMilliseconds;
                sw.Reset();
            }

            proc = Process.GetCurrentProcess();
            Console.WriteLine(proc.WorkingSet64 + "\n");

            Console.WriteLine($"Total start time: {startTicks} ticks");
            Console.WriteLine($"Average start time: {startTicks / threadCount} ticks\n");

            long runTicks = 0;

            foreach (Thread t in _pool)
            {
                sw.Start();

                t.Join();

                sw.Stop();
                //Console.WriteLine(sw.ElapsedTicks);  
                runTicks += sw.ElapsedMilliseconds;
                sw.Reset();
            }
            sw.Stop();

            _pool.Clear();

            Console.WriteLine($"Total run time: {runTicks} ticks");
            Console.WriteLine($"Average run time: {runTicks / threadCount} ticks");
            Console.ReadLine();
        }

        public static void WaitThread()
        {
            //throw new Exception("Thread exception");
            Thread.Sleep(5000);
            Console.WriteLine("Thread finished");
        }
    }
}
