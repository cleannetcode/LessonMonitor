using System;
using System.Threading;

namespace ThreadExamples
{
    public class ThreadMutexSemaphore
    {
        static Mutex mutexObj = new Mutex();
        static int x = 0;
     
        public static void RunDemo()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = $"Поток {i}";
                myThread.Start();
            }

            Console.ReadLine();

            for (int i = 1; i < 6; i++)
            {
                Reader reader = new Reader(i);
            }

            Console.ReadLine();
        }
        public static void Count()
        {
            mutexObj.WaitOne();
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            mutexObj.ReleaseMutex();
        }
    }

    class Reader
    {
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;

        public Reader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Читатель {i.ToString()}";
            myThread.Start();
        }

        public void Read()
        {
            while (count > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

                Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                sem.Release();

                count--;
                Thread.Sleep(1000);
            }
        }
    }
}
