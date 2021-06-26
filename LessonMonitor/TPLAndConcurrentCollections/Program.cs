using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TPLAndConcurrentCollections
{
	class Program
	{
		static void Main(string[] args)
		{
			var guids = new Guid[100];

			for (int i = 0; i < guids.Length; i++)
				guids[i] = Guid.NewGuid();

			var stopwatch = new Stopwatch();

			stopwatch.Start();

			var options = new ParallelOptions
			{
				MaxDegreeOfParallelism = 4
			};

			var index = -1;
			var locker = new object();

			var random = new Random();
			var randomIndex = random.Next(0, 100);

			Parallel.For(0, 100,
				(i, state) =>
				{
					Thread.Sleep(1000);
					if (guids[i] == guids[randomIndex])
					{
						Interlocked.Exchange(ref index, i);
						state.Stop();
					}
				});

			Console.WriteLine($"{guids[randomIndex]} == {guids[index]}");


			//Parallel.ForEach(guids, (guid, state) =>
			//{
			//	Console.WriteLine($"{guid}");
			//});


			//for (int i = 0; i < 10; i++)
			//{
			//	Thread.Sleep(1000);
			//}

			stopwatch.Stop();

			Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000.0);
		}

		private void TestInvoke()
		{
			var actions = new List<Action>();

			for (int i = 0; i < 100; i++)
				actions.Add(() => Console.WriteLine($"{i} {Thread.CurrentThread.ManagedThreadId}"));

			for (int i = 0; i < 100; i++)
			{
				Parallel.Invoke(actions.ToArray());

				Console.WriteLine();
				Console.ReadKey();
			}
		}
	}
}
