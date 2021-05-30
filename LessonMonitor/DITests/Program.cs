using Microsoft.Extensions.DependencyInjection;
using System;

namespace DITests
{
	class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			var collection = new ServiceCollection();

			collection.AddScoped<IUsersService>(x =>
			{
				var client = x.GetService<IGithubClient>();
				var usersService = new UsersService(client);

				return new UsersServiceCache(usersService);
			});

			collection.AddScoped<IPullRequestService, PullRequestService>();
			collection.AddTransient<IGithubClient, GithubClient>();

			var provider = collection.BuildServiceProvider();

			using (var scope = provider.CreateScope())
			{
				var usersService = scope.ServiceProvider.GetService<IUsersService>();
				var pullRequestService = scope.ServiceProvider.GetService<IPullRequestService>();
				var controller = new UsersController(usersService, pullRequestService);
				controller.Print();
			}

			//using (var scope = provider.CreateScope())
			//{
			//	var usersService = scope.ServiceProvider.GetService<UsersService>();
			//	var pullRequestService = scope.ServiceProvider.GetService<PullRequestService>();
			//	var controller = new UsersController(usersService, pullRequestService);
			//	controller.Print();
			//}
		}

		private static void SingletonMultipleRequests()
		{
			var client = new GithubClient();
			var usersService = new UsersService(client);
			var pullRequestService = new PullRequestService(client);

			// requests - scope
			{
				var controller = new UsersController(usersService, pullRequestService);
				controller.Print();
			}

			// requests - scope
			{
				var controller = new UsersController(usersService, pullRequestService);
				controller.Print();
			}
		}


		private static void MultipleRequests()
		{
			// requests - scope
			{
				var client = new GithubClient();
				var usersService = new UsersService(client);
				var pullRequestService = new PullRequestService(client);
				var controller = new UsersController(usersService, pullRequestService);

				controller.Print();
			}

			// requests - scope
			{
				var client = new GithubClient();
				var usersService = new UsersService(client);
				var pullRequestService = new PullRequestService(client);
				var controller = new UsersController(usersService, pullRequestService);

				controller.Print();
			}
		}

		private static void SingleRequest()
		{
			var client = new GithubClient();
			var usersService = new UsersService(client);
			var pullRequestService = new PullRequestService(client);
			var controller = new UsersController(usersService, pullRequestService);

			controller.Print();
			controller.Print();
			controller.Print();
		}
    }
}
