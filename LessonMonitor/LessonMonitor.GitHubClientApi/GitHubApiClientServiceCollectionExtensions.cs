using LessonMonitor.Core.GitHub;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Octokit;
using System;

namespace LessonMonitor.GitHubClientApi
{
    public static class GitHubApiClientServiceCollectionExtensions
    {
        private const string GIT_HUB_OWNER_SECTION = "GitHubConfig";

        public static void AddGitHubApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGitHubApiClient, GitHubApiClient>(x =>
            {
                var githubConfig = configuration.GetSection(GIT_HUB_OWNER_SECTION).Get<GitHubConfig>();

                if (githubConfig == null)
                    throw new Exception($"Section \"{GIT_HUB_OWNER_SECTION}\" doesn't confugured");

                if (githubConfig.Owner == null)
                    throw new Exception($"Value \"{nameof(githubConfig.Owner)}\" of Section {GIT_HUB_OWNER_SECTION} doesn't confugured");

                if (githubConfig.Repository == null)
                    throw new Exception($"Value \"{nameof(githubConfig.Repository)}\" of Section {GIT_HUB_OWNER_SECTION} doesn't confugured");

                var headerValue = new ProductHeaderValue(githubConfig.Owner);

                var client = new GitHubClient(headerValue);

                var tokenAuth = new Credentials("Insert a token here");

                client.Credentials = tokenAuth;

                return new GitHubApiClient(client, githubConfig.Owner, githubConfig.Repository);
            });
        }
    }
}
