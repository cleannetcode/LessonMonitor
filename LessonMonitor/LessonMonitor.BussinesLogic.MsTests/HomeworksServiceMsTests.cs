using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using LessonMonitor.Core.Repositories;

namespace LessonMonitor.BussinesLogic.MsTests
{
    [TestClass]
    public class HomeworksServiceMsTests
    {
        private readonly Mock<IHomeworksRepository> _homeworkRepositoryMock;
        private readonly HomeworksService _service;

        public HomeworksServiceMsTests()
        {
            _homeworkRepositoryMock = new Mock<IHomeworksRepository>();
            _service = new HomeworksService(_homeworkRepositoryMock.Object);
        }

        // unit testing name patterns (find name methods for test in google)
        // MethodName_Conditions_Result
        [TestMethod]
        public void Create_HomeworkIsValide_ShouldCreateNewHomework()
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var homework = fixture.Build<Homework>()
                .Without(x => x.MentorId)
                .Create();

            //var homeworks = fixture.CreateMany<Homework>(5);

            // act - запускаем тестируемый метод
            var result = _service.Create(homework);

            // assert - проверяем/валидируем результаты теста
            result.Should().BeTrue();
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Once);
        }

        [TestMethod]
        public void Create_HomeworkIsNull_ShouldThrowArgumentNullException()
        {
            // arrange 
            Homework homework = null;

            // act 
            bool result = false;

            var exceprtion = Assert.ThrowsException<ArgumentNullException>(() => result = _service.Create(homework));

            // assert
            exceprtion.Should().NotBeNull()
                .And.Match<ArgumentNullException>(x => x.ParamName == "homework");

            result.Should().BeFalse();
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-456)]
        [DataRow(-45654)]
        [DataRow(-1546454)]
        public void Create_HomeworkIsInvalide_ShouldThrowBusinessExceprion(int memberId)
        {
            // arrange
            var homework = new Homework();
            homework.MemberId = memberId;

            // act
            bool result = false;

            var exceprtion = Assert.ThrowsException<HomeworkException>(() => result = _service.Create(homework));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<HomeworkException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

            result.Should().BeFalse();
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [TestMethod]
        public void Delete_ShouldDeleteHomework()
        {
            // arrange
            var fixture = new Fixture();

            var homeworkId = fixture.Create<int>();

            // act
            var result = _service.Delete(homeworkId);

            // assert
            result.Should().BeTrue();
            _homeworkRepositoryMock.Verify(x => x.Delete(homeworkId), Times.Once);
        }
    }
}
