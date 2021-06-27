using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TasksExamples
{
    public class TPLAndConcurrentCollections
    {
        public static void RunDemo()
        {
            // TestInvok();
            // TestParallel();
            ParallelFor();
            ParallelForEach();
        }

        private static void ParallelForEach()
        {
            var guids = new Guid[100];

            for (int i = 0; i < guids.Length; i++)
            {
                guids[i] = Guid.NewGuid();
            }

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 4
            };

            var index = -1;
            var locker = new object();

            var randomIndex = new Random().Next(1, 100);

            Parallel.ForEach(guids, (guid, state) =>
            {
                Console.WriteLine($"guid: {guid} - state {state} - index {index++}");
            });

            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000.0);

            Console.WriteLine();
            Console.ReadKey();
        }

        private static void ParallelFor()
        {
            var guids = new Guid[100];

            for (int i = 0; i < guids.Length; i++)
            {
                guids[i] = Guid.NewGuid();
            }

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 4
            };

            var index = -1;
            var locker = new object();

            var randomIndex = new Random().Next(1, 40);

            Parallel.For(0, 40,
                 (i, state) =>
                 {
                     Thread.Sleep(1000);

                     if (guids[i] == guids[randomIndex])
                     {
                         Interlocked.Add(ref index, i);
                         state.Break();
                     }
                 });

            Console.WriteLine($"{guids[randomIndex]} == {guids[index]}");

            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000.0);

            Console.WriteLine();
            Console.ReadKey();
        }

        private static void TestParallel()
        {
            var numbers = new Guid[100];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Guid.NewGuid();
            }

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 2
            };

            Parallel.For(0, 15, options, (i) =>
            {
                Thread.Sleep(1000);

                Console.WriteLine($"{i} - {numbers[i]}");
            });

            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000.0);

            Console.WriteLine();
            Console.ReadKey();
        }

        private static void TestInvok()
        {
            var actions = new List<Action>();

            for (int i = 0; i < 100; i++)
            {
                actions.Add(() => Console.WriteLine($"{i} {Thread.CurrentThread.ManagedThreadId}"));
            }

            for (int i = 0; i < 100; i++)
            {
                Parallel.Invoke(actions.ToArray());

                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}
