using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WorkWithTasks
{
	class Program
	{
		private static List<int> _numbers = new List<int>();

		[STAThread]
		static void Main(string[] args)
		{
			Start().Wait();
			Console.ReadKey();
		}

		private static async Task Start()
		{
			await Task.Delay(200);
			Thread.Sleep(100);
		}

		private static void RunTaskBasics()
		{
			// Action, Func, Predicate

			for (int i = 0; i < 100; i++)
			{
				//var task = new Task<int>(DoAction);

				var cancellationTokenSource = new CancellationTokenSource(new TimeSpan(0, 0, 1));

				var task = DoActionAsync(cancellationTokenSource.Token);

				var task1 = new Task((x) =>
				{
					lock (_numbers)
					{
						_numbers.Add(1);
					}

					//Task.Delay(40000, cancellationTokenSource.Token).Wait();

					Console.WriteLine($"Message from task1. " +
						$"ThreadId:{Thread.CurrentThread.ManagedThreadId} " +
						$"TaskId: {Task.CurrentId}");
				}, cancellationTokenSource.Token);

				//var taskFactory = new TaskFactory();
				//taskFactory.StartNew(() =>
				//{
				//	Console.WriteLine($"Message from task2. " +
				//		$"ThreadId:{Thread.CurrentThread.ManagedThreadId} " +
				//		$"TaskId: {Task.CurrentId}");
				//	throw new Exception("task2");

				//});

				//Task.Factory.StartNew(() =>
				//{
				//	Console.WriteLine($"Message from task3. " +
				//		$"ThreadId:{Thread.CurrentThread.ManagedThreadId} " +
				//		$"TaskId: {Task.CurrentId}");
				//	throw new Exception("task3");
				//});

				//var task4 = Task.Run(() =>
				//{
				//	Console.WriteLine($"Message from task4. " +
				//		$"ThreadId:{Thread.CurrentThread.ManagedThreadId} " +
				//		$"TaskId: {Task.CurrentId}");
				//	throw new Exception("task4");
				//});

				task.Start();
				task1.Start();

				//task.Wait();
				var resultTask = Task.WhenAll(task, task1)
					.ContinueWith((x) =>
					{
						Console.WriteLine($"Message from continue with. " +
							$"ThreadId:{Thread.CurrentThread.ManagedThreadId} " +
							$"TaskId: {Task.CurrentId}");

						if (task.IsCompleted)
						{
							Console.WriteLine(task.Result);
						}

						Console.WriteLine($"[{string.Join(", ", _numbers)}]");
						_numbers.Clear();
					});

				resultTask.Wait();

				Console.WriteLine(Task.CompletedTask.Id);

				Console.ReadKey();
				Console.WriteLine();
			}
		}

		private static int DoAction()
		{
			Console.WriteLine($"Message from task. " +
						$"ThreadId:{Thread.CurrentThread.ManagedThreadId} " +
						$"TaskId: {Task.CurrentId}");

			return 42;
		}

		private static Task<int> DoActionAsync(CancellationToken token)
		{
			return Task.Run(async () =>
			{
				lock (_numbers)
				{
					_numbers.Add(0);
				}

				Console.WriteLine($"Message from task. " +
						$"ThreadId:{Thread.CurrentThread.ManagedThreadId} " +
						$"TaskId: {Task.CurrentId}");

				var guid = await GenerateGuid();
				Console.WriteLine(guid);

				for (int i = 0; i < 100000; i++)
				{

					//Thread.Sleep(1000);
					//token.ThrowIfCancellationRequested();
					if (token.IsCancellationRequested)
					{
						return 100;
					}
				}

				return 42;
			});
		}

		private static async Task<string> GenerateGuid()
		{
			return await Task.Run(async () =>
			{
				for (int i = 0; i < 1000; i++)
				{
					Guid.NewGuid().ToString();
				}

				var guid = Guid.NewGuid().ToString();

				return guid;
			}).ConfigureAwait(false);
		}

		private static async void ThrowException()
		{
			var guid = await Task.Run(() => Guid.NewGuid().ToString());
			throw new Exception("test");
		}

		private static void ProcessException()
		{
			ThrowException();
		}


	}

	public class Worker
	{
		public void Start()
		{
			AsyncVoidExceptions_CannotBeCaughtByCatch();
		}

		private async void ThrowExceptionAsync()
		{
			throw new InvalidOperationException();
		}

		private void AsyncVoidExceptions_CannotBeCaughtByCatch()
		{
			try
			{
				ThrowExceptionAsync();
			}
			catch (Exception)
			{
				// The exception is never caught here!
				throw;
			}
		}
	}
}
