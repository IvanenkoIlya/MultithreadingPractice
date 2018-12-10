using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingPractice
{
    public class PassingAndReturningFromThread
    {
        public delegate void ThreadCallback(int x);

        public static void Run()
        {
            ThreadWithState tws = new ThreadWithState(5, 7, PrintThreadResult);

            Thread t = new Thread(new ThreadStart(tws.ThreadProc));

            t.Start();
            t.Join();

            Console.ReadLine();
        }

        public static void PrintThreadResult(int x)
        {
            Console.WriteLine($"Main got result: {x}");
        }

        public class ThreadWithState
        {
            private int x;
            private int y;
            private ThreadCallback callback;

            public ThreadWithState(int x, int y, ThreadCallback tc)
            {
                this.x = x;
                this.y = y;
                this.callback = tc;
            }

            public void ThreadProc()
            {
                Console.WriteLine($"Thread proc adding numbers: {x} + {y} = {x + y}");

                callback?.Invoke(x + y);
            }
        }
    }
}
