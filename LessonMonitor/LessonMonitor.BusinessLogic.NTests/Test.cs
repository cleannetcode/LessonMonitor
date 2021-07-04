using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.BusinessLogic.NTests
{
	public class ConcurrentStackTests
	{
		[Test]
		[Repeat(100)]
		public void Test()
		{
			var stack = new Stack<int>();
			Parallel.For(0, 10, i => stack.Push(i));

			//Parallel.ForEach(stack, number =>
			//{
			//	Console.WriteLine(number);
			//});


			//for (int i = 0; i < 10; i++)
			//{
			//	stack.Push(i);
			//}

			Console.WriteLine(string.Join(", ", stack));

			Assert.AreEqual(10, stack.Count);
		}

	}
}
