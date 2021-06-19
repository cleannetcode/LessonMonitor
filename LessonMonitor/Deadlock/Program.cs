using System;
using System.Threading;

namespace Deadlock
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 0; i < 100; i++)
			{
				var worker = new MutexWorker();
				//var thread1 = new Thread(worker.Start);
				//var thread2 = new Thread(worker.Work);

				//thread1.Start();
				//thread2.Start();
				ThreadPool.QueueUserWorkItem((x) => worker.Start());
				ThreadPool.QueueUserWorkItem((x) => worker.Work());

				Console.WriteLine("Press any key to exit");
				Console.ReadKey();
			}
		}
	}

	public class MutexWorker
	{
		private static Mutex A = new Mutex();
		private static Mutex B = new Mutex();

		public void Start()
		{
			A.WaitOne();
			var processorId = Thread.GetCurrentProcessorId();
			var name = Thread.CurrentThread.Name;
			var threadId = Thread.CurrentThread.ManagedThreadId;

			B.WaitOne();
			Console.WriteLine("processorId: " + processorId);
			Console.WriteLine("name: " + name);
			Console.WriteLine("threadId: " + threadId);
			B.ReleaseMutex();

			A.ReleaseMutex();
		}

		public void Work()
		{
			B.WaitOne();
			var processorId = Thread.GetCurrentProcessorId();
			var name = Thread.CurrentThread.Name;
			var threadId = Thread.CurrentThread.ManagedThreadId;

			A.WaitOne();
			Console.WriteLine("processorId: " + processorId);
			Console.WriteLine("name: " + name);
			Console.WriteLine("threadId: " + threadId);
			A.ReleaseMutex();

			B.ReleaseMutex();
		}
	}

	public class Worker
	{
		private object A = new object();
		private object B = new object();

		public void Start()
		{
			lock (A)
			{
				var processorId = Thread.GetCurrentProcessorId();
				var name = Thread.CurrentThread.Name;
				var threadId = Thread.CurrentThread.ManagedThreadId;

				Console.WriteLine("processorId: " + processorId);
				Console.WriteLine("name: " + name);
				Console.WriteLine("threadId: " + threadId);

				lock (B)
				{
				}
			}
		}

		public void Work()
		{
			lock (B)
			{
				var processorId = Thread.GetCurrentProcessorId();
				var name = Thread.CurrentThread.Name;
				var threadId = Thread.CurrentThread.ManagedThreadId;

				Console.WriteLine("processorId: " + processorId);
				Console.WriteLine("name: " + name);
				Console.WriteLine("threadId: " + threadId);

				lock (A)
				{
				}
			}
		}
	}
}
