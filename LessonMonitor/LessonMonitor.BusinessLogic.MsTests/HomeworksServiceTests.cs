using AutoFixture;
using FluentAssertions;
using FluentAssertions.Common;
using LessonMonitor.Core;
using LessonMonitor.Core.Exeptions;
using LessonMonitor.Core.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace LessonMonitor.BusinessLogic.MSTests
{
    [TestClass]
    public class HomeworksServiceTests
    {
        private readonly Mock<IHomeworksRepository> homeworksRepositoryMock;
        private readonly HomeworksService service;

        public HomeworksServiceTests()
        {
            homeworksRepositoryMock = new Mock<IHomeworksRepository>();
            service = new HomeworksService(homeworksRepositoryMock.Object);
        }
        [TestMethod]
        public void Create_HomeworkIsValid_ShouldCreateNewHomework()
        {
            var fixture = new Fixture();

            var homework = fixture.Build<Homework>()
                .Create();

            var result = service.Create(homework);

            result.Should().BeTrue();
            homeworksRepositoryMock.Verify(x => x.Add(homework), Times.Once);
        }
        [TestMethod]
        public void Create_HomeworkIsNull_ShouldThrowNullException()
        {
            //arange

            bool result = false;
            Homework homework = null;
            //act

            var exception =  Assert.ThrowsException<ArgumentNullException>(() => result = service.Create(homework));
            //assert

            exception.Should().NotBeNull()
                .And
                .Match<ArgumentNullException>(x => x.ParamName == "homework");

            result.Should().BeFalse();
            homeworksRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }
        [TestMethod]
        [DataRow(0)]
        [DataRow(-124)]
        [DataRow(-24122)]
        public void Create_HomeworkIsInvalid_ShouldThrowBisinessException(int memberId)
        {
            //arrange

            var homework = new Homework();
            homework.MemberId = memberId;
            //act

            bool result = false;
            var exception = Assert.ThrowsException<BusinessException>(() => result = service.Create(homework));
            //assert

            exception.Should().NotBeNull()
                .And
                .Match<BusinessException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

            result.Should().BeFalse();
            homeworksRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }
        [TestMethod]
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