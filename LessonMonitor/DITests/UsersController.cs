using System;

namespace DITests
{
	public class UsersController : IUsersController
	{
		private readonly IUsersService _usersService;
		private readonly IPullRequestService _pullRequestService;
		private readonly Guid _guid;
		public UsersController(IUsersService usersService, IPullRequestService pullRequestService)
		{
			_guid = Guid.NewGuid();
			_usersService = usersService;
			_pullRequestService = pullRequestService;
		}

		public void Print()
		{
			Console.WriteLine(nameof(UsersController) + " - " + _guid);
			_usersService.Print();
			_pullRequestService.Print();
		}
	}
}
