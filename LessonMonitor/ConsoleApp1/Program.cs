using System;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Task
            var thread1 = new Thread(DoAction);
            thread1.Name = "thread1";
            var thread2 = new Thread(new ThreadStart(DoAction));
            thread2.Name = "thread2";
            var thread3 = new Thread(() => DoAction());
            thread3.Name = "thread3";

            thread1.Priority = ThreadPriority.Highest;
            thread2.Priority = ThreadPriority.Highest;
            thread3.Priority = ThreadPriority.Highest;

            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(DoAction);
                thread.Priority = ThreadPriority.Lowest;
                thread.Start();
            }

            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        public static void DoAction()
        {
            var processorId = Thread.GetCurrentProcessorId();
            var name = Thread.CurrentThread.Name;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var priority = Thread.CurrentThread.Priority;
            var threadState = Thread.CurrentThread.ThreadState;
            var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;

            Console.WriteLine(isThreadPoolThread);
            //Console.WriteLine(name);
            //Console.WriteLine(threadId);
            //Console.WriteLine(priority);
            //Console.WriteLine(threadState);
        }
    }
}
