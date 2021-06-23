using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadExamples
{
    public class ThreadLessonWork
    {
        public static void RunDemo()
        {
            var worker = new Worker();

            ThreadPool.QueueUserWorkItem((x) => worker.AddNumber());
            //ThreadPool.QueueUserWorkItem((x) => worker.AddNumber());
            //ThreadPool.QueueUserWorkItem((x) => worker.AddNumber());
            //ThreadPool.QueueUserWorkItem((x) => worker.AddNumber());

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            Console.WriteLine(worker);
        }

		public static string PrintThreadInfo(int myThreadId)
		{
			var processorId = Thread.GetCurrentProcessorId();
			var name = Thread.CurrentThread.Name;
			var threadId = Thread.CurrentThread.ManagedThreadId;
			var priority = Thread.CurrentThread.Priority;
			var threadState = Thread.CurrentThread.ThreadState;
			var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
			var isBackground = Thread.CurrentThread.IsBackground;

			Console.WriteLine("myThreadId: " + myThreadId);

			Console.WriteLine("processorId: " + processorId);
			Console.WriteLine("name: " + name);
			Console.WriteLine("threadId: " + threadId);
			Console.WriteLine("priority: " + priority);
			Console.WriteLine("threadState: " + threadState);
			Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
			Console.WriteLine("isBackground: " + isBackground);
			Console.WriteLine();

			return Guid.NewGuid().ToString();
		}
	}
	public class Worker
	{
		private List<int> _numbers = new List<int>();
		private int _counter = 0;
		private Random _random = new Random();

		private Mutex _mutex = new Mutex(false, "Mutex");
		private AutoResetEvent _autoResetEvent = new AutoResetEvent(true);
		private Semaphore _semaphore = new Semaphore(1, 1);
		private SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

		public void AddNumberWithSemaphorSlim()
		{
			_semaphoreSlim.Wait();
			_numbers.Add(_random.Next());
			_counter++;

			var processorId = Thread.GetCurrentProcessorId();
			var name = Thread.CurrentThread.Name;
			var threadId = Thread.CurrentThread.ManagedThreadId;
			var priority = Thread.CurrentThread.Priority;
			var threadState = Thread.CurrentThread.ThreadState;
			var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
			var isBackground = Thread.CurrentThread.IsBackground;

			Console.WriteLine("processorId: " + processorId);
			Console.WriteLine("name: " + name);
			Console.WriteLine("threadId: " + threadId);
			Console.WriteLine("priority: " + priority);
			Console.WriteLine("threadState: " + threadState);
			Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
			Console.WriteLine("isBackground: " + isBackground);
			Console.WriteLine();

			_semaphoreSlim.Release();
		}

		public void AddNumberSemaphore()
		{
			_semaphore.WaitOne();
			_numbers.Add(_random.Next());
			_counter++;

			var processorId = Thread.GetCurrentProcessorId();
			var name = Thread.CurrentThread.Name;
			var threadId = Thread.CurrentThread.ManagedThreadId;
			var priority = Thread.CurrentThread.Priority;
			var threadState = Thread.CurrentThread.ThreadState;
			var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
			var isBackground = Thread.CurrentThread.IsBackground;

			Console.WriteLine("processorId: " + processorId);
			Console.WriteLine("name: " + name);
			Console.WriteLine("threadId: " + threadId);
			Console.WriteLine("priority: " + priority);
			Console.WriteLine("threadState: " + threadState);
			Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
			Console.WriteLine("isBackground: " + isBackground);
			Console.WriteLine();

			_semaphore.Release();
		}

		public void AddNumberWithAuthResetEvent()
		{
			_autoResetEvent.WaitOne();
			_numbers.Add(_random.Next());
			_counter++;

			var processorId = Thread.GetCurrentProcessorId();
			var name = Thread.CurrentThread.Name;
			var threadId = Thread.CurrentThread.ManagedThreadId;
			var priority = Thread.CurrentThread.Priority;
			var threadState = Thread.CurrentThread.ThreadState;
			var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
			var isBackground = Thread.CurrentThread.IsBackground;

			Console.WriteLine("processorId: " + processorId);
			Console.WriteLine("name: " + name);
			Console.WriteLine("threadId: " + threadId);
			Console.WriteLine("priority: " + priority);
			Console.WriteLine("threadState: " + threadState);
			Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
			Console.WriteLine("isBackground: " + isBackground);
			Console.WriteLine();

			_autoResetEvent.Set();
		}

		public void AddNumberWithLock()
		{
			lock (_numbers)
			{
				_numbers.Add(_random.Next());
				_counter++;
			}

			var processorId = Thread.GetCurrentProcessorId();
			var name = Thread.CurrentThread.Name;
			var threadId = Thread.CurrentThread.ManagedThreadId;
			var priority = Thread.CurrentThread.Priority;
			var threadState = Thread.CurrentThread.ThreadState;
			var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
			var isBackground = Thread.CurrentThread.IsBackground;

			Console.WriteLine("processorId: " + processorId);
			Console.WriteLine("name: " + name);
			Console.WriteLine("threadId: " + threadId);
			Console.WriteLine("priority: " + priority);
			Console.WriteLine("threadState: " + threadState);
			Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
			Console.WriteLine("isBackground: " + isBackground);
			Console.WriteLine();
		}

		public void AddNumber()
		{
			_mutex.WaitOne();
			_numbers.Add(_random.Next());
			_counter++;
			_mutex.ReleaseMutex();

			var processorId = Thread.GetCurrentProcessorId();
			var name = Thread.CurrentThread.Name;
			var threadId = Thread.CurrentThread.ManagedThreadId;
			var priority = Thread.CurrentThread.Priority;
			var threadState = Thread.CurrentThread.ThreadState;
			var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
			var isBackground = Thread.CurrentThread.IsBackground;

			Console.WriteLine("processorId: " + processorId);
			Console.WriteLine("name: " + name);
			Console.WriteLine("threadId: " + threadId);
			Console.WriteLine("priority: " + priority);
			Console.WriteLine("threadState: " + threadState);
			Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
			Console.WriteLine("isBackground: " + isBackground);
			Console.WriteLine();
		}

		public override string ToString()
		{
			return $"counter: {_counter}, numbers: [{string.Join(", ", _numbers)}]";
		}
	}

}
