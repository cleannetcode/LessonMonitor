using AutoFixture;
using AutoMapper;
using FluentAssertions;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Moq;
using System.Collections.Generic;
using LessonMonitor.Core.Exceptions;
using LessonMonitor.Core.GitHub;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LessonMonitor.BusinessLogic.XTests
{
    public class MembersServiceTests
    {
        private readonly Fixture _fixture;
        private readonly Mock<IMembersRepository> _membersRepositoryMock;
        private readonly Mock<IGitHubApiClient> _githubApiClientMock;
        private readonly MembersService _service;

        public MembersServiceTests()
        {
            _fixture = new Fixture();
            _membersRepositoryMock = new Mock<IMembersRepository>();
            _githubApiClientMock = new Mock<IGitHubApiClient>();

            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BusinessLogicMappingProfile>();
            }));

            _service = new MembersService(mapper, _membersRepositoryMock.Object, _githubApiClientMock.Object);
        }

        [Fact]
        public async Task Create_ValidMember_ShouldReturnCreatedMemberId()
        {
            // arrange
            var expectedMemberId = _fixture.Create<int>();

            var member = _fixture.Build<Member>()
                .Without(x => x.Id)
                .Create();

            _membersRepositoryMock
                .Setup(x => x.Add(member))
                .ReturnsAsync(expectedMemberId);

            // act
            var memberId = await _service.Create(member);

            // assert
            Assert.Equal(expectedMemberId, memberId);
            _membersRepositoryMock.Verify(x => x.Get(member.YouTubeUserId), Times.Once);
            _membersRepositoryMock.Verify(x => x.Add(member), Times.Once);
        }

        [Fact]
        public async Task Create_MemberAlreadyExists_ShouldUpdateExistedMember()
        {
            // arrange
            var youTubeUserId = _fixture.Create<string>();

            var existedMember = _fixture.Build<Member>()
                .With(x => x.YouTubeUserId, youTubeUserId)
                .Create();

            var member = _fixture.Build<Member>()
                .With(x => x.YouTubeUserId, youTubeUserId)
                .Without(x => x.Id)
                .Create();

            _membersRepositoryMock
                .Setup(x => x.Get(member.YouTubeUserId))
                .ReturnsAsync(existedMember);

            _membersRepositoryMock
                .Setup(x => x.Update(member));

            // act
            await _service.Create(member);

            // assert
            _membersRepositoryMock.Verify(x => x.Get(member.YouTubeUserId), Times.Once);
            _membersRepositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
            _membersRepositoryMock.Verify(x => x.Update(member), Times.Once);
        }

        [Fact]
        public async Task Create_MemberIsNull_ShouldThrowArgumentNullException()
        {
            // arrange
            // act
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(null));

            // assert
            _membersRepositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }

        [Theory]
        [InlineData(142, "test", "test")]
        [InlineData(-53, "test", "test")]
        [InlineData(0, null, "test")]
        [InlineData(0, "", "test")]
        [InlineData(0, " ", "test")]
        [InlineData(0, "test", null)]
        [InlineData(0, "test", "")]
        [InlineData(0, "test", " ")]
        [InlineData(0, null, null)]
        [InlineData(0, "", "")]
        [InlineData(53, " ", " ")]
        [InlineData(0, null, " ")]
        public async Task Create_InvalidMember_ShouldThrowArgumentNullException(int id, string name, string youtubeUserId)
        {
            // arrange
            var member = new Member
            {
                Id = id,
                Name = name,
                YouTubeUserId = youtubeUserId
            };

            // act
            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.Create(member));

            // assert
            _membersRepositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }

        [Fact]
        public async Task Get_ShouldReturnMembers()
        {
            // arrange
            var expectedMembers = _fixture
                .CreateMany<Member>(42)
                .ToArray();

            _membersRepositoryMock
                .Setup(x => x.Get())
                .ReturnsAsync(expectedMembers);

            // act
            var members = await _service.Get();

            // assert
            members.Should().NotBeNullOrEmpty()
                .And.HaveCount(expectedMembers.Length);

            _membersRepositoryMock.Verify(x => x.Get(), Times.Once);
        }

        [Fact]
        public async Task Get_YoutubeUserIdIsValide_ShouldReturnMember()
        {
            // arrange
            var youTubeUserId = _fixture.Create<string>();

            var expectedMember = _fixture.Build<Member>()
                .With(x => x.YouTubeUserId, youTubeUserId)
                .Create();

            _membersRepositoryMock.Setup(x => x.Get(youTubeUserId))
                .ReturnsAsync(expectedMember);

            // act
            var member = await _service.Get(youTubeUserId);

            // assert
            member.Should()
                .NotBeNull()
                .And
                .Match<Member>(x => x.YouTubeUserId == youTubeUserId);

            _membersRepositoryMock.Verify(x => x.Get(youTubeUserId), Times.Once);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task Get_YoutubeUserIdIsNotValide_ShouldThrowArgumentException(string youTubeUserId)
        {
            // arrange
            // act
            await Assert.ThrowsAsync<ArgumentException>(() => _service.Get(youTubeUserId));

            // assert
            _membersRepositoryMock.Verify(x => x.Get(youTubeUserId), Times.Never);
        }

        [Fact]
        public async Task GetStatistics_MemberIdIsValide_ShouldReturnMemberStatistics()
        {
            // arrange
            var memberId = _fixture.Create<int>();

            var expectedMemberName = _fixture.Create<string>();

            var expectedMembers = _fixture.Build<MemberStatistic>()
                .With(x => x.MemberName, expectedMemberName)
                .CreateMany()
                .ToArray();

            _membersRepositoryMock.Setup(x => x.GetStatistics(memberId))
                .ReturnsAsync(expectedMembers);

            // act
            var memberStatisrics = await _service.GetStatistics(memberId);

            // assert
            memberStatisrics.Should()
                .NotBeNull()
                .And
                .HaveCount(expectedMembers.Length)
                .And
                .Match<MemberStatistic[]>(x => x.All(f => f.MemberName == expectedMemberName));

            _membersRepositoryMock.Verify(x => x.GetStatistics(memberId), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-14)]
        [InlineData(-1255512)]
        public async Task GetStatistics_MemberIdIsNotValide_ShouldThrowArgumentException(int memberId)
        {
            // arrange
            // act
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetStatistics(memberId));

            // assert
            _membersRepositoryMock.Verify(x => x.GetStatistics(memberId), Times.Never);
        }

        [Fact]
        public async Task GetHomeworks_MemberIdIsValid_ShouldReturnHomeworks()
        {
            // arrange
            var memberId = _fixture.Create<int>();

            var githubAccount = _fixture.Build<GitHubAccount>()
                .Without(x => x.Member)
                .With(x => x.MemberId, memberId)
                .Create();

            var approvedPullRequests = _fixture.Build<PullRequest>()
                .With(x => x.GithubAccountId, githubAccount.GithubAccountId)
                .With(x => x.IsApproved, true)
                .CreateMany()
                .ToArray();

            var pullRequests = _fixture.Build<PullRequest>()
                .With(x => x.GithubAccountId, githubAccount.GithubAccountId)
                .With(x => x.IsApproved, false)
                .CreateMany()
                .Union(approvedPullRequests)
                .ToArray();

            _membersRepositoryMock
                .Setup(x => x.GetGitHubAccount(memberId))
                .ReturnsAsync(githubAccount);

            _githubApiClientMock
                .Setup(x => x.GetPullRequests(githubAccount.GithubAccountId))
                .ReturnsAsync(pullRequests);

            // act
            var homeworks = await _service.GetHomeworks(memberId);

            // assert
            homeworks.Should().NotBeEmpty()
                .And.HaveCount(pullRequests.Length)
                .And.Match<MemberHomework[]>(x => x.Count(p => p.IsApproved) == approvedPullRequests.Length);

            _membersRepositoryMock.Verify(x => x.GetGitHubAccount(memberId), Times.Once);
            _githubApiClientMock.Verify(x => x.GetPullRequests(githubAccount.GithubAccountId), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-142)]
        [InlineData(-142346436)]
        public async Task GetHomeworks_MemberIdIsNotValid_ShouldThrowArgumentException(int memberId)
        {
            // arrange
            // act
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetHomeworks(memberId));

            // assert
            _membersRepositoryMock.Verify(x => x.GetGitHubAccount(It.IsAny<int>()), Times.Never);
            _githubApiClientMock.Verify(x => x.GetPullRequests(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task GetHomeworks_MemberHaventGithubAccount_ShouldThrowBusinessException()
        {
            // arrange
            var memberId = _fixture.Create<int>();

            _membersRepositoryMock
                .Setup(x => x.GetGitHubAccount(memberId))
                .ReturnsAsync(() => null);

            // act
            await Assert.ThrowsAsync<BusinessException>(() => _service.GetHomeworks(memberId));

            // assert
            _membersRepositoryMock.Verify(x => x.GetGitHubAccount(memberId), Times.Once);
            _githubApiClientMock.Verify(x => x.GetPullRequests(It.IsAny<int>()), Times.Never);
        }
    }
}
