using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using Moq;
using NUnit.Framework;
using System;
using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.BussinesLogic.NTests
{
    public class HomeworksServiceNTests
    {
        private Mock<IHomeworksRepository> _homeworkRepositoryMock;
        private HomeworksService _service;

        public HomeworksServiceNTests() {}

        [SetUp]
        public void SetUp()
        {
            _homeworkRepositoryMock = new Mock<IHomeworksRepository>();
            _service = new HomeworksService(_homeworkRepositoryMock.Object);
        }

        // unit testing name patterns (find name methods for test in google)
        // MethodName_Conditions_Result
        [Test]
        public void Create_HomeworkIsValide_ShouldCreateNewHomework()
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var homework = fixture.Build<Homework>()
                .Without(x => x.Topic)
                .Without(x => x.User)
                .Create();

            //var homeworks = fixture.CreateMany<Homework>(5);

            // act - запускаем тестируемый метод
            var result = _service.Create(homework);

            // assert - проверяем/валидируем результаты теста
            result.Should().BeTrue();
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Once);
        }

        [Test]
        public void Create_HomeworkIsNull_ShouldThrowArgumentNullException()
        {
            // arrange 
            Homework homework = null;

            // act 
            bool result = false;

            var exceprtion = Assert.Throws<ArgumentNullException>(() => result = _service.Create(homework));

            // assert
            exceprtion.Should().NotBeNull()
                .And.Match<ArgumentNullException>(x => x.ParamName == "homework");

            result.Should().BeFalse();
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [TestCase(0)]
        [TestCase(-236)]
        [TestCase(-53236)]
        [TestCase(-742364366)]
        public void Create_HomeworkIsInvalide_ShouldThrowBusinessExceprion(int homeworkId)
        {
            // arrange
            var fixture = new Fixture();

            var homework = fixture.Build<Homework>()
                .Without(x => x.Topic)
                .Without(x => x.User)
                .Create();

            homework.Id = homeworkId;

            // act
            bool result = false;

            var exceprtion = Assert.Throws<HomeworkException>(() => result = _service.Create(homework));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<HomeworkException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

            result.Should().BeFalse();
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [Test]
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

        [Test]
        public void Update_HomeworkIsValide_ShouldUpdateHomework()
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var homework = fixture.Build<Homework>()
                .Without(x => x.Topic)
                .Without(x => x.User)
                .Create();

            // act - запускаем тестируемый метод
            var result = _service.Update(homework);

            // assert - проверяем/валидируем результаты теста
            result.Should().BeTrue();
            _homeworkRepositoryMock.Verify(x => x.Update(homework), Times.Once);
        }

        [TestCase(0)]
        [TestCase(-236)]
        [TestCase(-53236)]
        [TestCase(-742364366)]
        public void Update_HomeworkIsInvalide_ShouldThrowBusinessExceprion(int homeworkId)
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var homework = fixture.Build<Homework>()
                .Without(x => x.Topic)
                .Without(x => x.User)
                .Create();

            homework.Id = homeworkId;

            // act
            bool result = false;

            var exceprtion = Assert.Throws<HomeworkException>(() => result = _service.Update(homework));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<HomeworkException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

            result.Should().BeFalse();
            _homeworkRepositoryMock.Verify(x => x.Update(homework), Times.Never);
        }

        [Test]
        public void Update_HomeworkIsINull_ShouldThrowBusinessExceprion()
        {
            // arrange 
            Homework homework = null;

            // act 
            bool result = false;

            var exceprtion = Assert.Throws<ArgumentNullException>(() => result = _service.Update(homework));

            // assert
            exceprtion.Should().NotBeNull()
                .And.Match<ArgumentNullException>(x => x.ParamName == "homework");

            result.Should().BeFalse();
            _homeworkRepositoryMock.Verify(x => x.Update(homework), Times.Never);
        }
    }
}
