using Octokit;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HowToWorkGitHub
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var headerValue = new ProductHeaderValue("cleannetcode");
            var client = new GitHubClient(headerValue);

            var repository = await client.Repository.Get("cleannetcode", "LessonMonitor");

            var pullRequests = await client.PullRequest.GetAllForRepository(repository.Id);

            foreach (var pullRequest in pullRequests)
            {
                Console.WriteLine(pullRequest.User.Id + " " + pullRequest.User.Login);
                Console.WriteLine(pullRequest.CreatedAt + " " + pullRequest.Title);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
