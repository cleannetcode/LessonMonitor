namespace ThreadExamples
{
    internal class Program
	{
		private static void Main(string[] args)
		{
			Deadlock.RunDemo();

			ThreadLessonWork.RunDemo();

			ThreadStartTest.RunDemo();

			ThreadingMonitor.RunDemo();

			ThreadMutexSemaphore.RunDemo();

			ThreadingTimerCallback.RunDemo();
		}
	}
}
