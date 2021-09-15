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

            await GetRateInfo();

            Console.WriteLine(("").PadRight(20, '-'));

            await GetRateInfoWithToken();

            Console.ReadKey();
        }

        public static async Task GetRateInfo()
        {
            var headerValue = new ProductHeaderValue("cleannetcode");

            var client = new GitHubClient(headerValue);

            var isAuthenticationType = client.Credentials.AuthenticationType;

            var miscellaneousRateLimit = await client.Miscellaneous.GetRateLimits();

            var rateLimit = miscellaneousRateLimit.Resources.Core;

            var howManyRequestsCanIMakePerHour = rateLimit.Limit;
            var howManyRequestsDoIHaveLeft = rateLimit.Remaining;
            var whenDoesTheLimitReset = rateLimit.Reset;

            var searchRateLimit = miscellaneousRateLimit.Resources.Search;

            var howManySearchRequestsCanIMakePerMinute = searchRateLimit.Limit;
            var howManySearchRequestsDoIHaveLeft = searchRateLimit.Remaining;
            var whenDoesTheSearchLimitReset = searchRateLimit.Reset;

            Console.WriteLine("Without Token");
            Console.WriteLine($"isAuthenticationType: {isAuthenticationType}");
            Console.WriteLine($"rateLimit: {rateLimit}");
            Console.WriteLine($"howManyRequestsCanIMakePerHour: {howManyRequestsCanIMakePerHour}");
            Console.WriteLine($"howManyRequestsDoIHaveLeft: {howManyRequestsDoIHaveLeft}");
            Console.WriteLine($"whenDoesTheLimitReset: {whenDoesTheLimitReset}");
            Console.WriteLine($"searchRateLimit: {searchRateLimit}");
            Console.WriteLine($"howManySearchRequestsCanIMakePerMinute: {howManySearchRequestsCanIMakePerMinute}");
            Console.WriteLine($"howManySearchRequestsDoIHaveLeft: {howManySearchRequestsDoIHaveLeft}");
            Console.WriteLine($"whenDoesTheSearchLimitReset: {whenDoesTheSearchLimitReset}");
        }

        public static async Task GetRateInfoWithToken()
        {
            var headerValue = new ProductHeaderValue("cleannetcode");

            var client = new GitHubClient(headerValue);

            var tokenAuth = new Credentials("Insert a token here");
            client.Credentials = tokenAuth;

            var isAuthenticationType = client.Credentials.AuthenticationType;

            var miscellaneousRateLimit = await client.Miscellaneous.GetRateLimits();

            var rateLimit = miscellaneousRateLimit.Resources.Core;

            var howManyRequestsCanIMakePerHour = rateLimit.Limit;
            var howManyRequestsDoIHaveLeft = rateLimit.Remaining;
            var whenDoesTheLimitReset = rateLimit.Reset;

            var searchRateLimit = miscellaneousRateLimit.Resources.Search;

            var howManySearchRequestsCanIMakePerMinute = searchRateLimit.Limit;
            var howManySearchRequestsDoIHaveLeft = searchRateLimit.Remaining;
            var whenDoesTheSearchLimitReset = searchRateLimit.Reset;

            Console.WriteLine("With Token");
            Console.WriteLine($"isAuthenticationType: {isAuthenticationType}");
            Console.WriteLine($"rateLimit: {rateLimit}");
            Console.WriteLine($"howManyRequestsCanIMakePerHour: {howManyRequestsCanIMakePerHour}");
            Console.WriteLine($"howManyRequestsDoIHaveLeft: {howManyRequestsDoIHaveLeft}");
            Console.WriteLine($"whenDoesTheLimitReset: {whenDoesTheLimitReset}");
            Console.WriteLine($"searchRateLimit: {searchRateLimit}");
            Console.WriteLine($"howManySearchRequestsCanIMakePerMinute: {howManySearchRequestsCanIMakePerMinute}");
            Console.WriteLine($"howManySearchRequestsDoIHaveLeft: {howManySearchRequestsDoIHaveLeft}");
            Console.WriteLine($"whenDoesTheSearchLimitReset: {whenDoesTheSearchLimitReset}");
        }

        public static async Task GetPullRequestInfo()
        {
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
        }
    }
}
