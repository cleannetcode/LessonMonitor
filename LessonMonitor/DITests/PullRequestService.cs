using System;

namespace DITests
{
	public class PullRequestService : IPullRequestService
	{
		private readonly IGithubClient _githubClient;
		private readonly Guid _guid;
		public PullRequestService(IGithubClient githubClient)
		{
			_guid = Guid.NewGuid();
			_githubClient = githubClient;
		}

		public void Print()
		{
			Console.WriteLine(nameof(PullRequestService) + " - " + _guid);
			_githubClient.Print();
		}
	}
}
