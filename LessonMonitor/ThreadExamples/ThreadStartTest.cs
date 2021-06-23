using System;
using System.Threading;

namespace ThreadExamples
{
    public class ThreadStartTest
    {
        public static void RunDemo()
        {
            // создаем новый поток
            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start(); // запускаем поток

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Главный поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }

            Console.ReadLine();

            int number = 4;
            Thread myThread2 = new Thread(new ParameterizedThreadStart(CountWithParam));
            myThread2.Start(number);

            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Главный поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }

            Console.ReadLine();

            var counter = new Counter();
            counter.x = 4;
            counter.y = 5;

            Thread myThread3 = new Thread(new ParameterizedThreadStart(CountWithParams));
            myThread3.Start(counter);

            var counterWithThread = new CounterWithThread(5, 4);

            Thread myThread4 = new Thread(new ThreadStart(counterWithThread.Count));
            myThread4.Start();
        }

        public static void Count()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(400);
            }
        }

        public static void CountWithParam(object x)
        {
            for (int i = 1; i < 9; i++)
            {
                int n = (int)x;

                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * n);
                Thread.Sleep(400);
            }
        }

        public static void CountWithParams(object obj)
        {
            for (int i = 1; i < 9; i++)
            {
                Counter c = (Counter)obj;

                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * c.x * c.y);
            }
        }
    }

    public class Counter
    {
        public int x;
        public int y;
    }

    public class CounterWithThread
    {
        private int x;
        private int y;

        public CounterWithThread(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public void Count()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * x * y);
                Thread.Sleep(400);
            }
        }
    }
}
