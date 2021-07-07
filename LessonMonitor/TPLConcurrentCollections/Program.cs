using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TPLConcurrentCollections
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }

        private static async Task BlockingCollection()
        {
            var collection = new BlockingCollection<int>(5);

            var stopWatch = new Stopwatch();

            var tasks = new List<Task>();

            var writter = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    collection.Add(i);
                }

                collection.CompleteAdding();
            });

            tasks.Add(writter);

            var readers = new Task[1];

            for (int i = 0; i < readers.Length; i++)
            {
                readers[i] = Task.Run(async () =>
                {
                    while (!collection.IsAddingCompleted)
                    {
                        await Task.Delay(200);

                        var isSuccess = collection.TryTake(out var item, 1000);

                        if (isSuccess)
                        {
                            Console.WriteLine(item);
                        }
                    }
                });
            }

            tasks.AddRange(readers);

            stopWatch.Start();
            await Task.WhenAll(tasks);
            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000.0);

            Console.WriteLine();
            Console.ReadKey();

            collection.CompleteAdding();
        }

        private static void ConcurrentDictionary()
        {
            var dictionary = new ConcurrentDictionary<int, Person>();

            Parallel.For(0, 10, i => dictionary
            .AddOrUpdate(i,
            id => new Person
            {
                Id = id,
                Name = Guid.NewGuid().ToString(),
                Age = 15,
                BirthDate = DateTime.Now.AddYears(20)
            },
            (id, oldPerson) => new Person
            {
                Id = id,
                Name = oldPerson.Name + Guid.NewGuid().ToString(),
                Age = oldPerson.Age + 15,
                BirthDate = oldPerson.BirthDate
            }
            ));

            Parallel.For(0, 10, i => dictionary
            .AddOrUpdate(i,
            id => new Person
            {
                Id = id,
                Name = Guid.NewGuid().ToString(),
                Age = 15,
                BirthDate = DateTime.Now.AddYears(20)
            },
            (id, oldPerson) => new Person
            {
                Id = id,
                Name = oldPerson.Name + Guid.NewGuid().ToString(),
                Age = oldPerson.Age + 15,
                BirthDate = oldPerson.BirthDate
            }
            ));

            Parallel.ForEach(dictionary, person => Console.WriteLine(person));

            Console.ReadKey();
        }

        private static void UserConcuttentStack()
        {
            for (int i = 0; i < 100; i++)
            {
                var stack = new ConcurrentStack<int>();

                Parallel.For(0, 20, i => stack.Push(i));

                var actions = new List<Action>();

                Parallel.ForEach(stack, number =>
                {
                    Console.WriteLine(number);
                });

                while (stack.TryPop(out var number))
                {
                    Console.WriteLine(number);
                }

                Console.WriteLine();

                Console.ReadKey();
            }
        }

        private static void UserConcuttentQueue2()
        {
            var queue = new ConcurrentQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            var actions = new List<Action>();

            for (int i = 0; i < queue.Count; i++)
            {
                actions.Add(() =>
                {
                    var isSuccess = queue.TryDequeue(out var number);

                    if (isSuccess)
                    {
                        Console.WriteLine(number);
                    }

                    Console.ReadKey();
                });

            }

            Parallel.ForEach(queue, number =>
            {
                Console.WriteLine(number);
            });
        }

        private static void UseConcurrentQueue()
        {
            var queue = new ConcurrentQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");

            while (!queue.IsEmpty)
            {
                var isSuccess = queue.TryDequeue(out var number);

                if (isSuccess)
                {
                    Console.WriteLine(number);
                }

                Console.ReadKey();
            }
        }

        private static void UseConcurrentBag()
        {
            var bag = new ConcurrentBag<int>();

            for (int i = 0; i < 10; i++)
            {
                bag.Add(1);
            }

            while (!bag.IsEmpty)
            {
                var isSuccess = bag.TryTake(out var number);

                if (isSuccess)
                {
                    Console.WriteLine(number);
                }

                Console.ReadKey();
            }


            for (int i = 0; i < 2; i++)
            {
                var isSuccess = bag.TryTake(out var number);

                if (isSuccess)
                {
                    Console.WriteLine(number);
                }

                Console.ReadKey();
            }

            Parallel.For(0, 10, i => bag.Add(i));

            Parallel.ForEach(bag, number => Console.WriteLine(number));
        }

    }
}
