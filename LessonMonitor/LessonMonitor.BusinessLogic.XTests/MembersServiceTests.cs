using AutoFixture;
using AutoMapper;
using FluentAssertions;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Moq;
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
        private readonly MembersService _service;

        public MembersServiceTests()
        {
            _fixture = new Fixture();
            _membersRepositoryMock = new Mock<IMembersRepository>();

            var mapper = new Mapper(new MapperConfiguration(cfg => { }));

            _service = new MembersService(mapper, _membersRepositoryMock.Object);
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
    }
}
