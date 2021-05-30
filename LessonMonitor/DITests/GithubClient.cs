using System;

namespace DITests
{
	public class GithubClient : IGithubClient
	{
		private readonly Guid _guid;
		public GithubClient()
		{
			_guid = Guid.NewGuid();
		}

		public void Print() =>
			Console.WriteLine(nameof(GithubClient) + " - " + _guid);
	}
}
