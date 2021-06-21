using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using Moq;
using System;
using Xunit;
using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.BussinesLogic.XTests
{
    public class HomeworksServiceXTests
    {
        private Mock<IHomeworksRepository> _homeworkRepositoryMock;
        private HomeworksService _service;

        public HomeworksServiceXTests()
        {
            _homeworkRepositoryMock = new Mock<IHomeworksRepository>();
            _service = new HomeworksService(_homeworkRepositoryMock.Object);
        }

        // unit testing name patterns (find name methods for test in google)
        // MethodName_Conditions_Result
        [Fact]
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

        [Fact]
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

        [Theory]
        [InlineData(0)]
        [InlineData(-236)]
        [InlineData(-53236)]
        [InlineData(-742364366)]
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

        [Fact]
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
