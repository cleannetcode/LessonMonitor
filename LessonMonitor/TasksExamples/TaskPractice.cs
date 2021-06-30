using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TasksExamples
{
    public class TaskPractice
    {
        private const string MSG_INNER = "Inner task starting...";
        private const string MSG_OUTER = "Outer task starting...";
        private const string MSG_END = "End of Main";

        public static void RunDemo()
        {
            // выполняются асинхронно
            GetMultiplyedNumberAsync();
            Task.Run(() => GenerateIntAsync());
            ReadWriteAsync();

            Console.ReadKey();
        }

        public static async void ReadWriteAsync()
        {
            using (StreamReader reader = new StreamReader("data.txt"))
            {
                var result = await reader.ReadToEndAsync();

                Console.WriteLine(result);
            }
        }

        public static async void GetMultiplyedNumberAsync()
        {
            Console.WriteLine("Start of method");

            var result = -1;

            await Task.Factory.StartNew(() => RunTaskArrayWithPrint());

            Console.WriteLine($"{MSG_END}, Result = {result}");

        }

        public static void TaskAwait()
        {
            for (int i = 0; i < 100; i++)
            {
                var task = GenerateNumberAsync().ConfigureAwait(false);

                var result = task.GetAwaiter().GetResult(); ;

                Console.WriteLine($"await result: {result}");

                PrintInfo();

                Console.ReadKey();
            }
        }

        public static void TaskWaitAny()
        {
            Task[] tasks1 = new Task[10];

            for (int i = 0; i < tasks1.Length; i++)
            {
                tasks1[i] = new Task(() => PrintInfo());
            }

            foreach (var tast in tasks1)
            {
                tast.Start();
            }

            Task.WaitAny(tasks1);

            Console.WriteLine(MSG_END);

            Console.ReadKey();
        }

        public static void TaskWhenAll()
        {
            for (int i = 0; i < 100; i++)
            {
                var cancellationTokenSource = new CancellationTokenSource(new TimeSpan(0, 0, 1));

                var task = DoActionCancellation(cancellationTokenSource.Token);

                var task1 = new Task((x) =>
                {
                    Task.Delay(2000, cancellationTokenSource.Token).Wait();

                    PrintInfoTask();

                }, cancellationTokenSource.Token);

                Task.WhenAll(task, task1)
                    .ContinueWith((x) =>
                    {
                        PrintInfoTask();

                        if (task.IsCompleted)
                        {
                            Console.WriteLine($"Result int: {task.Result}");
                        }
                    })
                    .Wait();

                Console.WriteLine($"CompletedTask: {Task.CompletedTask.Id}");

                Console.ReadKey();
            }
        }

        public static void TaskParallelThreadCount()
        {
            List<int> threadIds = new List<int>();

            var ints = new int[25];

            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = GenerateNumber().Result;
            }

            Parallel.ForEach(ints, _int =>
            {

                var threadId = Thread.CurrentThread.ManagedThreadId;

                threadIds.Add(threadId);

                Console.WriteLine($"Int: {_int}, ThreadId: {threadId}");
            });

            Console.WriteLine($"Threads count: {threadIds.Count}");

            Console.ReadKey();
        }

        public static void TaskParallelForEach()
        {
            var ints = new int[50];

            var stopWatch = new Stopwatch();

            var value = -1;

            var randomIndex = new Random().Next(0, 50);

            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = GenerateNumber().Result;
            }

            stopWatch.Start();

            Parallel.ForEach(ints, (_int, loopState) =>
                 {
                     Thread.Sleep(2000);

                     Console.WriteLine($"Current Int: {_int}");
                     PrintInfoTask();

                     if (_int == ints[randomIndex])
                     {
                         Interlocked.Add(ref value, _int);
                         loopState.Break();
                     }
                 });

            Console.WriteLine($"The number is found: {ints[randomIndex]} == {value}");

            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000.0);

            Console.ReadKey();
        }

        public static void ParallelForEachBlockedLongIteration()
        {
            int inloop = 0;
            int completed = 0;

            var items = Enumerable.Repeat(10, 1000).ToArray();

            items[50] = 10000;

            Console.Write(0.ToString("000") + " Threads, " + 0.ToString("000") + " completed");

            var task = Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(items, (msToWait) =>
                {
                    Interlocked.Increment(ref inloop);

                    var e = DateTime.Now + new TimeSpan(0, 0, 0, 0, msToWait);

                    while (DateTime.Now < e)
                        Interlocked.Increment(ref completed);

                    Interlocked.Decrement(ref inloop);

                    //status
                    Console.Write("\r" + inloop.ToString("000") + " Threads, " + completed.ToString("000") + " completed");
                });
            });

            task.Wait();

            Console.WriteLine("\nDone!");
        }

        public static void TaskParallelFor()
        {
            var ints = new int[1000];

            var stopWatch = new Stopwatch();

            var index = -1;

            var randomIndex = GenerateNumber().Result;

            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = GenerateNumber().Result;
            }

            stopWatch.Start();

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 2
            };

            Parallel.For(0, 1000, options,
                 (i, state) =>
                 {
                     Thread.Sleep(1000);

                     if (ints[i] == ints[randomIndex])
                     {
                         Interlocked.Add(ref index, i);
                         state.Break();
                     }
                 });

            Console.WriteLine($"{ints[randomIndex]} == {ints[index]}");

            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000.0);

            Console.ReadKey();
        }

        public static void TestParallelInvok()
        {
            var actions = new List<Action>();

            for (int i = 0, j = 1; i < 100; i++)
            {
                actions.Add(() => Console.WriteLine($"Action index: {j++}, ThreadId:  {Thread.CurrentThread.ManagedThreadId}"));
            }

            for (int i = 0; i < 10; i++)
            {
                Parallel.Invoke(actions.ToArray());
            }

            Parallel.Invoke(
              () =>
              {
                  PrintInfoTask();
                  Thread.Sleep(2000);
              },
              () => Console.WriteLine(GenerateNumber().Result),
              () => Console.WriteLine(GenerateGuid().Result));

            Console.ReadKey();
        }

        public static void TaskContinueWith()
        {
            Task task1 = new Task(() =>
            {
                PrintInfoTask();
            });

            // задача продолжения
            Task task2 = task1.ContinueWith((Task task) =>
            {
                PrintInfoTask(task);
            });

            Task task3 = task1.ContinueWith((Task task) =>
            {
                PrintInfoTask(task);
            });

            Task task4 = task2.ContinueWith((Task task) =>
            {
                PrintInfoTask(task);
            });

            task1.Start();

            Console.ReadLine();
        }

        public static Task<int> TaskReturnsValue()
        {
            return Task.Run(() =>
            {
                PrintInfoTask();

                var taskNum = GenerateNumber();

                taskNum.Wait();

                if (taskNum.IsCompleted)
                {

                    return taskNum.Result;
                }
                else
                {
                    return 0;
                }
            });
        }

        public static void RunTaskArrayWithWaitAll()
        {
            Task[] tasks1 = new Task[10];
            Task[] tasks2 = new Task[10];

            for (int i = 0; i < tasks1.Length; i++)
            {
                tasks1[i] = new Task(() => PrintInfo());
            }

            foreach (var task in tasks1)
            {
                task.Start();
            }

            Task.WaitAll(tasks1);

            for (int i = 0, j = 0; i < tasks2.Length; i++)
            {
                tasks2[i] = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Message from task {j++}. " +
                                       $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                                       $"TaskId: {Task.CurrentId}");
                });
            }

            Console.WriteLine(MSG_END);

            Console.ReadLine();
        }

        public static void RunTaskArray()
        {
            List<Task> tasks1 = new List<Task>();
            Task[] tasks2 = new Task[10];

            for (int i = 0; i < 20; i++)
            {
                tasks1.Add(new Task(() => PrintInfo()));
            }

            foreach (var task in tasks1)
            {
                task.Start();
            }

            Console.WriteLine(MSG_END);

            Console.ReadLine();
        }

        // задача выполняется вместе с внешней
        public static void WorkBetweenTasks_Parrent()
        {
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine(MSG_OUTER);

                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine(MSG_INNER);

                    Thread.Sleep(2000);

                    Console.WriteLine(MSG_OUTER);

                }, TaskCreationOptions.AttachedToParent);
            });

            outer.Wait(); // ожидаем выполнения внешней задачи

            Console.WriteLine(MSG_END);

            Console.ReadLine();
        }

        public static void WorkBetweenTasks()
        {
            var outer = Task.Run(() =>
            {
                Console.WriteLine(MSG_OUTER);

                var inner = Task.Run(() =>
                {
                    Console.WriteLine(MSG_INNER);

                    Thread.Sleep(2000);

                    Console.WriteLine(MSG_OUTER);
                });
            });

            outer.Wait(); // ожидаем выполнения внешней задачи

            Console.WriteLine(MSG_END);

            Console.ReadLine();
        }

        public static void WorkBetweenTasks2()
        {
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine(MSG_OUTER);

                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine(MSG_INNER);

                    Thread.Sleep(2000);

                    Console.WriteLine(MSG_OUTER);
                });
            });

            outer.Wait(); // ожидаем выполнения внешней задачи

            Console.WriteLine(MSG_END);

            Console.ReadLine();
        }

        private static async void PrintInfo()
        {
            var guid = await Task.Run(() => Guid.NewGuid().ToString());

            Console.WriteLine($"Print: {guid}");
        }

        private static Task<string> GenerateGuid()
        {
            return Task.Run(() => Guid.NewGuid().ToString());
        }

        private static Task<int> GenerateNumber()
        {
            return Task.Run(() => new Random().Next(0, 1000));
        }

        private async static Task<int> GenerateNumberAsync()
        {
            return await Task.Run(() => new Random().Next(0, 1000));
        }
        private static int GenerateInt()
        {
            Console.WriteLine("GenerateInt is working..");

            var result = new Random().Next(0, 1000);

            for (int i = 1; i <= 5; i++)
            {
                result *= i;
            }

            Thread.Sleep(8000);

            Console.WriteLine($"GenerateInt end work. Result: {result}");

            return result;
        }

        private static async Task<int> GenerateIntAsync()
        {
            return await Task.Run(() => 
            {
                Console.WriteLine("GenerateInt is working..");

                var result = new Random().Next(0, 1000);

                for (int i = 1; i <= 5; i++)
                {
                    result *= i;
                }

                Thread.Sleep(8000);

                Console.WriteLine($"GenerateInt end work. Result: {result}");

                return result;
            });
        }

        private static void PrintInfoTask(Task task)
        {
            Console.WriteLine($"Message from task. " +
                $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                $"TaskCurrentId: {Task.CurrentId}, " +
                $"TaskStatus: {task.Status}");
        }

        private static void PrintInfoTask()
        {
            Console.WriteLine($"Message from task. " +
                $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                $"TaskId: {Task.CurrentId}");
        }

        private static Task<int> DoActionCancellation(CancellationToken token)
        {
            return new Task<int>(() =>
            {
                PrintInfoTask();

                for (int i = 0; i < 10000; i++)
                {
                    Thread.Sleep(1000);
                }

                if (token.IsCancellationRequested)
                {
                    return GenerateNumber().Result;
                }

                return 1;
            });
        }

        private static void RunTaskArrayWithPrint()
        {
            Task[] tasks1 = new Task[10];

            for (int i = 0; i < tasks1.Length; i++)
            {
                tasks1[i] = new Task(() => PrintInfo());
            }

            foreach (var tast in tasks1)
            {
                tast.Start();

                Thread.Sleep(2000);
            }
        }
    }
}