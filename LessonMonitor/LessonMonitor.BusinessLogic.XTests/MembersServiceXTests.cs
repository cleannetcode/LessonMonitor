using AutoFixture;
using FluentAssertions;
using LessonMonitor.BusinessLogic;
using LessonMonitor.Core;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LessonMonitor.BusinessLogic.XTests
{
    public class MembersServiceXTests
    {
        private readonly Fixture _fixture;
        private Mock<IMembersRepository> _membersRepositoryMock;
        private MembersService _service;

        public MembersServiceXTests()
        {
            _fixture = new Fixture();
            _membersRepositoryMock = new Mock<IMembersRepository>();
            _service = new MembersService(_membersRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_MemberIsValide_ShouldCreateNewMember()
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
            _membersRepositoryMock.Verify(x => x.Get(member.YouTubeAccountId), Times.Once);
            _membersRepositoryMock.Verify(x => x.Add(member), Times.Once);
        }

        [Fact]
        public async Task Create_MemberAlreadyExists_ShouldThrowInvalidaOperationException()
        {
            // arrange
            var member = _fixture.Build<Member>()
                .Without(x => x.Id)
                .Create();

            _membersRepositoryMock
                .Setup(x => x.Get(member.YouTubeAccountId))
                .ReturnsAsync(member);

            // act
            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.Create(member));

            // assert
            _membersRepositoryMock.Verify(x => x.Get(member.YouTubeAccountId), Times.Once);
            _membersRepositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }

        [Fact]
        public async Task Create_MemberIsNull_ShouldThrowArgumentNullException()
        {
            // arrange 
            Member member = null;

            // act 
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(member));

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
        public async Task Create_InvalidMember_ShouldThrowArgumentNullException(int id, string name, string youTubeAccountId)
        {
            // arrange
            var member = new Member
            {
                Id = id,
                Name = name,
                YouTubeAccountId = youTubeAccountId
            };

            // act
            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.Create(member));

            // assert
            _membersRepositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }

        [Fact]
        public async Task Delete_ShouldDeleteMember()
        {
            // arrange
            var memberId = _fixture.Create<int>();

            //act
            var result = await _service.Delete(memberId);

            // assert
            //result.Should().BeTrue();
            _membersRepositoryMock.Verify(x => x.Delete(memberId), Times.Once);
        }

        [Fact]
        public async Task Delete_MemberIdisDefault_ShouldMemberArgumentException()
        {
            // arrange
            // act
            await Assert.ThrowsAsync<MemberException>(() => _service.Delete(default));

            // assert
            _membersRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-123124)]
        [InlineData(-1)]
        public async Task Get_InvalidMemberId_ShouldReturnBussinesException(int questionId)
        {
            // arrange
            // act
            var exceprtion = await Assert.ThrowsAsync<MemberException>(() => _service.Get(questionId));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<MemberException>(x => x.Message == MembersService.MEMBER_IS_INVALID);

            _membersRepositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }

        [Fact]
        public async Task Get_DefaultMemberId_ShouldReturnBussinesException()
        {
            // arrange
            // act
            var exceprtion = await Assert.ThrowsAsync<MemberException>(() => _service.Get(default));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<MemberException>(x => x.Message == MembersService.MEMBER_IS_INVALID);

            _membersRepositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }
    }
}
