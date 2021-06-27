using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TasksExamples
{
    public class TasksLessonWork
    {
        private static List<int> _numbers = new List<int>();
        public static void RunDemo()
        {
            TasksAwait3();
            Console.ReadKey();

        }

        [STAThread]
        public static async void TasksAwait3()
        {
            for (int i = 0; i < 100; i++)
            {
                var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("https://www.google.com");

                var response = await httpClient.GetAsync("/").ConfigureAwait(true);

                Console.WriteLine($"await response: {response}");

                Console.ReadKey();
            }
        }

        [STAThread]
        public static void TasksAwait2()
        {
            for (int i = 0; i < 100; i++)
            {
                var task = GenerateGuid2().ConfigureAwait(false);

                var result = task.GetAwaiter().GetResult();

                Console.WriteLine($"await result: {result}");

                Console.ReadKey();
            }
        }

        public static async Task TasksAwait()
        {
            for (int i = 0; i < 100; i++)
            {
                var cancellationTokenSource = new CancellationTokenSource(new TimeSpan(0, 0, 1));
                var result = await DoActionAsync(cancellationTokenSource.Token)
                    .ConfigureAwait(true);


                Console.WriteLine($"await result: {result}");
                Console.WriteLine();

                PrintInfo();

                Console.ReadKey();
            }
        }

        public static void TestTasks3()
        {
            // Action, Func, Precidate

            // Пример инициализации таска
            var taskDelegate = new Task(delegate ()
            {

            });

            for (int i = 0; i < 100; i++)
            {
                //var taskSimple = new Task(() => result = DoAction());

                //var task = new Task<int>(DoAction);

                var cancellationTokenSource = new CancellationTokenSource(new TimeSpan(0, 0, 1));

                var task = DoActionAsync2(cancellationTokenSource.Token);

                var task1 = new Task((x) =>
                {
                    lock (_numbers)
                    {
                        _numbers.Add(1);

                    }

                    Task.Delay(40000, cancellationTokenSource.Token).Wait();

                    Console.WriteLine($"Message from task1. " +
                        $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                        $"TaskId: {Task.CurrentId}");

                }, cancellationTokenSource.Token);


                task1.Start();

                var resultTask = Task.WhenAll(task, task1)
                    .ContinueWith((x) =>
                    {
                        Console.WriteLine($"Message from continue with. " +
                           $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                           $"TaskId: {Task.CurrentId}");

                        if (task.IsCompleted)
                        {
                            Console.WriteLine($"Result int: {task.Result}");
                        }

                        Console.WriteLine($"[{string.Join(", ", _numbers)}]");
                        _numbers.Clear();
                    });

                resultTask.Wait();

                //if (task.IsCompleted)
                //{
                //    Console.WriteLine($"Result int: {task.Result}");
                //}

                Console.WriteLine($"CompletedTask: {Task.CompletedTask.Id}");

                Console.ReadKey();
                Console.WriteLine();
            }
        }

        public static void TestTasks2()
        {
            for (int i = 0; i < 100; i++)
            {
                //var taskSimple = new Task(() => result = DoAction());

                //var task = new Task<int>(DoAction);

                var cancellationTokenSource = new CancellationTokenSource(new TimeSpan(0, 0, 3));

                var task = DoActionAsync(cancellationTokenSource.Token);

                var task1 = new Task((x) =>
                {
                    Task.Delay(40000, cancellationTokenSource.Token).Wait();

                    Console.WriteLine($"Message from task1. " +
                        $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                        $"TaskId: {Task.CurrentId}");

                }, cancellationTokenSource.Token);

                Task.WhenAll(task, task1)
                    .ContinueWith((x) =>
                    {
                        Console.WriteLine($"Message from continue with. " +
                           $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                           $"TaskId: {Task.CurrentId}");

                        if (task.IsCompleted)
                        {
                            Console.WriteLine($"Result int: {task.Result}");
                        }
                    })
                    .Wait();

                Console.WriteLine($"CompletedTask: {Task.CompletedTask.Id}");

                Console.ReadKey();
                Console.WriteLine();
            }
        }

        public static void TestTasks()
        {
            // Action, Func, Precidate

            // Пример инициализации таска
            var taskDelegate = new Task(delegate ()
            {

            });

            for (int i = 0; i < 100; i++)
            {
                //var taskSimple = new Task(() => result = DoAction());

                var task = new Task<int>(DoAction);

                var task1 = new Task(() =>
                {
                    Console.WriteLine($"Message from task1. " +
                        $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                        $"TaskId: {Task.CurrentId}");
                    throw new Exception("task1");
                });

                var taskFactory = new TaskFactory();

                taskFactory.StartNew(() =>
                {
                    Console.WriteLine($"Message from task2. " +
                        $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                        $"TaskId: {Task.CurrentId}");
                    throw new Exception("task2");

                });

                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Message from task3. " +
                        $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                        $"TaskId: {Task.CurrentId}");
                    throw new Exception("task3");

                });

                var task4 = Task.Run(() =>
                {
                    Console.WriteLine($"Message from task4. " +
                        $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                        $"TaskId: {Task.CurrentId}");
                    throw new Exception("task4");

                });

                task.Start();
                task1.Start();

                task.Wait();

                if (task.IsCompleted)
                {
                    Console.WriteLine($"Result int: {task.Result}");
                }

                Console.WriteLine($"CompletedTask: {Task.CompletedTask.Id}");

                Console.ReadKey();
                Console.WriteLine();
            }
        }

        private static int DoAction()
        {
            Console.WriteLine($"Message from task. " +
                $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                $"TaskId: {Task.CurrentId}");

            return 23;
        }

        private static Task<int> DoActionAsync(CancellationToken token)
        {
            return Task.Run(() =>
            {
                lock (_numbers)
                {
                    _numbers.Add(0);

                }

                Console.WriteLine($"Message from task. " +
                  $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                  $"TaskId: {Task.CurrentId}");

                var task = GenerateGuid();

                task.Wait();

                if (task.IsCompleted)
                {
                    Console.WriteLine(task.Result);
                }

                for (int i = 0; i < 100000; i++)
                {
                    Thread.Sleep(1000);
                    token.ThrowIfCancellationRequested();
                }

                return 23;
            });
        }

        private static Task<int> DoActionAsync2(CancellationToken token)
        {
            return new Task<int>(() =>
            {
                lock (_numbers)
                {
                    _numbers.Add(0);

                }

                Console.WriteLine($"Message from task. " +
                  $"ThreadId: {Thread.CurrentThread.ManagedThreadId}, " +
                  $"TaskId: {Task.CurrentId}");

                for (int i = 0; i < 100000; i++)
                {
                    Thread.Sleep(1000);
                    //_numbers.Add(i);
                }

                if (token.IsCancellationRequested)
                {
                    return 100;
                }

                return 23;
            });
        }

        private static async void PrintInfo()
        {
           var guid = await Task.Run(() => Guid.NewGuid().ToString());

            Console.WriteLine($"PrintInfp: {guid}");

            throw new Exception("test");
        }

        private static Task<string> GenerateGuid()
        {
            return Task.Run(() => Guid.NewGuid().ToString());
        }

        private static async Task<string> GenerateGuid2()
        {
            return await Task.Run(() =>
            {
                var result = Guid.NewGuid().ToString();

                return result;

            });
        }
    }
}
