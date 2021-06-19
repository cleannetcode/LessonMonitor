using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
		private static Mutex _mutex = new Mutex(false, "Mutex");

		private static List<int> _numbers = new List<int>();
		private static List<Guid> _guids = new List<Guid>();

		private static Barrier _barrier;

		static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			_barrier = new Barrier(0, (x) =>
			{
				Console.WriteLine($"[{string.Join(", ", _numbers)}]");
				Console.WriteLine($"[{string.Join(", ", _guids)}]");
			});

			ThreadPool.QueueUserWorkItem((x) => GenerateNumber());
			ThreadPool.QueueUserWorkItem((x) => GenerateGuid());

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}

		private static void DoAction()
		{
			_mutex.WaitOne();

			Console.WriteLine("Test");

			_mutex.ReleaseMutex();
		}

		private static void GenerateNumber()
		{
			_barrier.AddParticipant();
			var random = new Random();

			for (int i = 0; i < 6; i++)
			{
				_numbers.Add(random.Next());
			}

			_barrier.SignalAndWait();
		}

		private static void GenerateGuid()
		{
			_barrier.AddParticipant();
			for (int i = 0; i < 2; i++)
			{
				_guids.Add(Guid.NewGuid());
			}

			_barrier.SignalAndWait();
		}
	}
}
