using LessonMonitor.Core.Exeptions;
using LessonMonitor.Core.Repository;
using LessonMonitor.Core;
using NUnit.Framework;
using System;
using Moq;
using AutoFixture;
using FluentAssertions;

namespace LessonMonitor.BusinessLogic.NTests
{
    public class HomeworksServiceTests
    {
        private Mock<IHomeworksRepository> homeworksRepositoryMock;
        private HomeworksService service;

        [SetUp]
        public void SetUp()
        {
            homeworksRepositoryMock = new Mock<IHomeworksRepository>();
            service = new HomeworksService(homeworksRepositoryMock.Object);
        }
        [Test]
        public void Create_HomeworkIsValid_ShouldCreateNewHomework()
        {
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
        [Test]
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
        [Test]
        [TestCase(0)]
        [TestCase(-124)]
        [TestCase(-24122)]
        public void Create_HomeworkIsInvalid_ShouldThrowBusinessException(int memberId)
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
        [Test]
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
        
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1999)]
        public void Delete_MemberIdIsInvalid_ShouldReturnBusinessException(int memberId)
        {
            // arange
            //var homework = new Homework();
            //homework.MemberId = memberId;
            bool result = false;

            //act
            var exception = Assert.Throws<BusinessException>(() => result = service.Delete(memberId));

            //assert
            exception.Should().NotBeNull()
                .And
                .Match<BusinessException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

            result.Should().BeFalse();
            homeworksRepositoryMock.Verify(x => x.Delete(memberId), Times.Never);
        }

        [Test]
        public void Update_HomeworkIsValid_ShouldUpdateHomework()
        {
            var fixture = new Fixture();
            var homework = fixture.Build<Homework>()
                .Create();

            var result = service.Update(homework);

            result.Should().BeTrue();
            homeworksRepositoryMock.Verify(x => x.Update(homework), Times.Once);
        }

        [Test]
        public void Update_HomeworkIsNull_ShouldThrowArgumentNullException()
        {
            //arange
            var result = false;
            Homework homework = null;

            //act
            var exception = Assert.Throws<ArgumentNullException>(() => result = service.Update(homework));

            //assert
            result.Should().BeFalse();
            exception.Should().NotBeNull()
                .And
                .Match<ArgumentNullException>(x => x.ParamName == "homework");
            homeworksRepositoryMock.Verify(x => x.Update(homework), Times.Never);
        }
        [Test]
        public void Update_HomeworkInValid_ShouldReturnBusinessException()
        {
            //arange
            var fixture = new Fixture();
            var homework = fixture.Build<Homework>()
                .With(x => x.MemberId, -10)
                .Without(x => x.MentorId)
                .Create();

            //act
            var result = false;
            var exception = Assert.Throws<BusinessException>(() => result = service.Update(homework));
            
            //assert
            exception.Should().NotBeNull()
                .And
                .Match<BusinessException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

            result.Should().BeFalse();
            homeworksRepositoryMock.Verify(x => x.Update(homework), Times.Never);
        }

    }
}
