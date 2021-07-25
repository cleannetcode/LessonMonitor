using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LessonMonitor.BusinessLogic.Validators;
using LessonMonitor.Core;
using LessonMonitor.Core.Exceptions;
using LessonMonitor.Core.GitHub;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;

namespace LessonMonitor.BusinessLogic
{
    public class MembersService : IMembersService
    {
        private readonly IMapper _mapper;
        private readonly IMembersRepository _membersRepository;
        private readonly IGitHubApiClient _gitHubApiClient;

        public MembersService(IMapper mapper, IMembersRepository membersRepository, IGitHubApiClient gitHubApiClient)
        {
            _mapper = mapper;
            _membersRepository = membersRepository;
            _gitHubApiClient = gitHubApiClient;
        }

        public async Task<int> Create(Member newMember)
        {
            if (newMember is null)
            {
                throw new ArgumentNullException(nameof(newMember));
            }

            var validator = new MemberValidator();
            var validationResult = await validator.ValidateAsync(newMember);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.ToString(", ");
                throw new InvalidOperationException(errors);
            }

            var existedMember = await _membersRepository.Get(newMember.YouTubeUserId);
            if (existedMember != null)
            {
                var updatedMember = _mapper.Map(newMember, existedMember);
                updatedMember.Id = existedMember.Id;

                await _membersRepository.Update(updatedMember);

                return existedMember.Id;
            }

            return await _membersRepository.Add(newMember);
        }

        public async Task<Member[]> Get()
        {
            return await _membersRepository.Get();
        }

        public async Task<Member> Get(string youtubeUserId)
        {
            if (string.IsNullOrWhiteSpace(youtubeUserId))
            {
                throw new ArgumentException($"'{nameof(youtubeUserId)}' cannot be null or whitespace", nameof(youtubeUserId));
            }

            return await _membersRepository.Get(youtubeUserId);
        }

        public async Task<MemberStatistic[]> GetStatistics(int memberId)
        {
            if (memberId <= default(int))
            {
                throw ExceptionHelper.CreateArgumentShoulBeGreaterThanZeroException(nameof(memberId));
            }

            return await _membersRepository.GetStatistics(memberId);
        }

        public async Task<MemberHomework[]> GetHomeworks(int memberId)
        {
            if (memberId <= default(int))
            {
                throw ExceptionHelper.CreateArgumentShoulBeGreaterThanZeroException(nameof(memberId));
            }

            var githubAccount = await _membersRepository.GetGitHubAccount(memberId);

            if (githubAccount == null)
            {
                throw new BusinessException("Member haven't github account");
            }

            var pullRequests = await _gitHubApiClient.GetPullRequests(githubAccount.GithubAccountId);

            var homeworks = new List<MemberHomework>();

            foreach (var pullRequest in pullRequests)
            {
                var homework = _mapper.Map<PullRequest, MemberHomework>(pullRequest);
                homework.MemberId = memberId;
                homeworks.Add(homework);
            }

            return homeworks.ToArray();
        }
    }
}
