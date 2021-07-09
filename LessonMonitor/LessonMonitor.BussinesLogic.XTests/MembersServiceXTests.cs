using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core.CoreModels;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LessonMonitor.BussinesLogic.XTests
{
    public class MembersServiceXTests
    {
        private Mock<IMembersRepository> _membersRepositoryMock;
        private MembersService _service;

        public MembersServiceXTests()
        {
            _membersRepositoryMock = new Mock<IMembersRepository>();
            _service = new MembersService(_membersRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_MemberIsValide_ShouldCreateNewMember()
        {
            // arrange
            var fixture = new Fixture();
            var expectedMemberId = fixture.Create<int>();
            var member = fixture.Build<Member>().Create();

            _membersRepositoryMock.Setup(x => x.Add(member))
                .ReturnsAsync(expectedMemberId);

            // act
            var result = await _service.Create(member);

            // assert
            result.Should().Be(expectedMemberId);
            _membersRepositoryMock.Verify(x => x.Add(member), Times.Once);
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
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task Create_MemberIsInvalide_ShouldThrowBusinessExceprion(string name)
        {
            // arrange
            var fixture = new Fixture();
            var member = fixture.Build<Member>()
                .Create();
            member.Name = name;

            // act
            var exceprtion = await Assert.ThrowsAsync<MemberException>(() => _service.Create(member));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<MemberException>(x => x.Message == MembersService.MEMBER_IS_INVALID);

            _membersRepositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }

        [Fact]
        public async Task Delete_ShouldDeleteMember()
        {
            // arrange
            var fixture = new Fixture();
            var memberId = fixture.Create<int>();

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
