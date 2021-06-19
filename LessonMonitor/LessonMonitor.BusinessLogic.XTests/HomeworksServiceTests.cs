using LessonMonitor.Core.Exeptions;
using LessonMonitor.Core.Repository;
using LessonMonitor.Core;
using FluentAssertions;
using System;
using Xunit;
using Moq;
using AutoFixture;

namespace LessonMonitor.BusinessLogic.XTests
{
    public class HomeworksServiceTests
    {
        private Mock<IHomeworksRepository> homeworksRepositoryMock;
        private HomeworksService service;

        public HomeworksServiceTests()
        {
            homeworksRepositoryMock = new Mock<IHomeworksRepository>();
            service = new HomeworksService(homeworksRepositoryMock.Object);
        }
        [Fact]
        public void Create_HomeworkIsValid_ShouldCreateNewHomework()
        {
            // var fixture = new Fixture();

            var homework = new Homework
            {
                Link = "link",
                Title = "title",
                MemberId = 12,
                MentorId = 10
            };

            var result = service.Create(homework);

            result.Should().BeTrue();
            homeworksRepositoryMock.Verify(x => x.Add(homework), Times.Once);
        }
        [Fact]
        public void Create_HomeworkIsNull_ShouldThrowNullException()
        {
            //arange

            bool result = false;
            Homework homework = null;
            //act

            var exception = Assert.Throws<ArgumentNullException>(() => result = service.Create(homework));
            //assert

            exception.Should().NotBeNull()
                .And
                .Match<ArgumentNullException>(x => x.ParamName == "homework");

            result.Should().BeFalse();
            homeworksRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-124)]
        [InlineData(-24122)]
        public void Create_HomeworkIsInvalid_ShouldThrowBisinessException(int memberId)
        {
            //arrange

            var homework = new Homework();
            homework.MemberId = memberId;
            //act

            bool result = false;
            var exception = Assert.Throws<BusinessException>(() => result = service.Create(homework));
            //assert

            exception.Should().NotBeNull()
                .And
                .Match<BusinessException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

            result.Should().BeFalse();
            homeworksRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }
        [Fact]
        public void Delete_ShouldDeletedHomework()
        {
            //arange
            var fixture = new Fixture();
            var homeworkId = fixture.Create<int>();
            //act

            var result = service.Delete(homeworkId);
            //assert

            homeworksRepositoryMock.Verify(x => x.Delete(homeworkId), Times.Once);
            result.Should().BeTrue();
        }
    }
}
