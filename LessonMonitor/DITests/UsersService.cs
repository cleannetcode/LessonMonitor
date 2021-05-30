using System;

namespace DITests
{
	public class UsersService : IUsersService
	{
		private readonly IGithubClient _githubClient;
		private readonly Guid _guid;
		public UsersService(IGithubClient githubClient)
		{
			_guid = Guid.NewGuid();
			_githubClient = githubClient;
		}

		public void Print()
		{
			Console.WriteLine(nameof(UsersService) + " - " + _guid);
			_githubClient.Print();
		}
	}

	public class UsersServiceCache : IUsersService
	{
		private readonly IUsersService _usersService;
		private readonly Guid _guid;
		public UsersServiceCache(IUsersService usersService)
		{
			_guid = Guid.NewGuid();
			_usersService = usersService;
		}

		public void Print()
		{
			Console.WriteLine(nameof(UsersServiceCache) + " - " + _guid);
			_usersService.Print();
		}
	}
}
