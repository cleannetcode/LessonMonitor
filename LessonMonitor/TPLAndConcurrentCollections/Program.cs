using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TPLAndConcurrentCollections
{
	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }

		public override string ToString()
		{
			return $"Id:{Id}, Name:{Name}, BirthDate:{BirthDate}";
		}
	}

	class Program
	{
		// мультритрединг vs параллельность
		static async Task Main(string[] args)
		{
			var queue = new ConcurrentQueue<int>();
			var collection = new BlockingCollection<int>(queue, 2);

			collection.Add(1);
			collection.CompleteAdding();

			var item = collection.Take();
			Console.WriteLine(item);
			item = collection.Take();
			Console.WriteLine(item);
		}

		private static async Task UseBlockingCollection()
		{
			var collection = new BlockingCollection<int>(2);

			var tasks = new List<Task>();

			var writer = Task.Run(() =>
			{
				for (int i = 0; i < 10; i++)
				{
					collection.Add(i);
				}

				collection.CompleteAdding();
			});

			tasks.Add(writer);

			var readers = new Task[5];

			for (int i = 0; i < readers.Length; i++)
			{
				readers[i] = Task.Run(async () =>
				{
					while (!collection.IsCompleted)
					{
						await Task.Delay(1000);
						var isSuccess = collection.TryTake(out var item, 1000);

						if (isSuccess)
						{
							Console.WriteLine(item);
						}
					}
				});
			}

			tasks.AddRange(readers);

			var stopwatch = new Stopwatch();
			stopwatch.Start();
			await Task.WhenAll(tasks);
			stopwatch.Stop();

			Console.WriteLine();
			Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000);
		}

		private static void UseConcurrentDictionary()
		{
			var dictionary = new ConcurrentDictionary<int, Person>();

			Parallel.For(0, 10, i => dictionary
				.AddOrUpdate(i,
				id => new Person
				{
					Id = id,
					Name = Guid.NewGuid().ToString(),
					BirthDate = DateTime.Now.AddYears(20)
				},
				(id, oldPerson) => new Person
				{
					Id = oldPerson.Id,
					Name = oldPerson.Name + Guid.NewGuid().ToString(),
					BirthDate = oldPerson.BirthDate
				}));

			Parallel.For(0, 10, i => dictionary
				.AddOrUpdate(i,
				id => new Person
				{
					Id = id,
					Name = Guid.NewGuid().ToString(),
					BirthDate = DateTime.Now.AddYears(20)
				},
				(id, oldPerson) => new Person
				{
					Id = oldPerson.Id,
					Name = oldPerson.Name + Guid.NewGuid().ToString(),
					BirthDate = oldPerson.BirthDate
				}));

			Parallel.ForEach(dictionary, person => Console.WriteLine(person));

			//for (int i = 0; i < 10; i++)
			//{
			//	dictionary[i] = new Person
			//	{
			//		Id = i,
			//		Name = Guid.NewGuid().ToString(),
			//		BirthDate = DateTime.Now.AddYears(20)
			//	};
			//}

			//var person = dictionary[5];
			//Console.WriteLine(person);
		}

		private static void UseConcurrentStack()
		{
			var stack = new ConcurrentStack<int>();
			Parallel.For(0, 10, i => stack.Push(i));

			//Parallel.ForEach(stack, number =>
			//{
			//	Console.WriteLine(number);
			//});


			//for (int i = 0; i < 10; i++)
			//{
			//	stack.Push(i);
			//}

			while (stack.TryPop(out var number))
			{
				Console.Write(number);
			}

			Console.WriteLine();
		}

		private static void UseConcurrentQueue()
		{
			var queue = new ConcurrentQueue<int>();

			Parallel.For(0, 10, i => queue.Enqueue(i));

			foreach (var item in queue)
			{
				Console.WriteLine(item);
			}

			//Console.WriteLine();

			//Parallel.ForEach(queue, number =>
			//{
			//	Console.WriteLine(number);
			//});

			//foreach (var item in queue)
			//{
			//	Console.WriteLine(item);
			//}

			//Console.WriteLine();

			//while (!queue.IsEmpty)
			//{
			//	var isSuccess = queue.TryDequeue(out var number);

			//	if (isSuccess)
			//	{
			//		Console.WriteLine(number);
			//	}

			//	Console.ReadKey();
			//}
		}

		private static void UseConcurrentBag()
		{
			var bag = new ConcurrentBag<int>();

			for (int i = 0; i < 10; i++)
			{
				bag.Add(i);
			}
			//Parallel.For(0, 10, i => bag.Add(i));
			//Parallel.ForEach(bag, number => Console.WriteLine(number));

			//foreach (var number in bag)
			//{
			//	Console.WriteLine(number);
			//}

			while (!bag.IsEmpty)
			{
				var isSuccess = bag.TryTake(out var number);

				if (isSuccess)
				{
					Console.WriteLine(number);
				}
			}
		}

		private static void RunTpl()
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
