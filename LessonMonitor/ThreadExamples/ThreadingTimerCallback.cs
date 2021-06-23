using System;
using System.Threading;

namespace ThreadExamples
{
    public class ThreadingTimerCallback
    {
        // TimerCallback необходим для запуска метода через каждые 2000 миллисекунд, то есть раз в две секунды.
        public static void RunDemo()
        {
            int num = 0;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            // создаем таймер
            Timer timer = new Timer(tm, num, 0, 2000);

            Console.ReadLine();
        }

        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
        }
    }
}
