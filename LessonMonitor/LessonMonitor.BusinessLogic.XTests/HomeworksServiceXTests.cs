using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using LessonMonitor.Core;

namespace LessonMonitor.BusinessLogic.XTests
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

        [Fact]
        public async Task Create_HomeworkIsValide_ShouldCreateNewHomework()
        {
            // arrange
            var fixture = new Fixture();
            var expectedHomeworkId = fixture.Create<int>();
            var homework = fixture.Build<Homework>().Create();

            _homeworkRepositoryMock.Setup(x => x.Add(homework))
                .ReturnsAsync(expectedHomeworkId);

            // act
            var result = await _service.Create(homework);

            // assert
            result.Should().Be(expectedHomeworkId);
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Once);
        }

        [Fact]
        public async Task Create_HomeworkIsNull_ShouldThrowArgumentNullException()
        {
            // arrange 
            Homework homework = null;

            // act 
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(homework));

            // assert
            _homeworkRepositoryMock.Verify(x => x.Add(It.IsAny<Homework>()), Times.Never);
        }

        [Theory]
        [InlineData(null, "Test")]
        [InlineData(null, "")]
        [InlineData(null, " ")]
        [InlineData("Test", null)]
        [InlineData("", null)]
        [InlineData(" ", null)]
        [InlineData("Test", " ")]
        [InlineData("Test", "")]
        [InlineData(" ", "Test")]
        [InlineData("", "Test")]
        public async Task Create_HomeworkIsInvalide_ShouldThrowBusinessExceprion(string title, string description)
        {
            // arrange
            var fixture = new Fixture();
            var homework = fixture.Build<Homework>()
                .Create();
            homework.Title = title;
            homework.Description = description;

            // act
            var exceprtion = await Assert.ThrowsAsync<HomeworkException>(() => _service.Create(homework));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<HomeworkException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

            _homeworkRepositoryMock.Verify(x => x.Add(It.IsAny<Homework>()), Times.Never);
        }

        [Fact]
        public async Task Delete_ShouldDeleteHomework()
        {
            // arrange
            var fixture = new Fixture();
            var homeworkId = fixture.Create<int>();

            // act
            var result = await _service.Delete(homeworkId);

            // assert
            //result.Should().BeTrue();
            _homeworkRepositoryMock.Verify(x => x.Delete(homeworkId), Times.Once);
        }

        [Fact]
        public async Task Delete_HomeworkIdisDefault_ShouldHomeworkArgumentException()
        {
            // arrange
            // act
            await Assert.ThrowsAsync<HomeworkException>(() => _service.Delete(default));

            // assert
            _homeworkRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task Update_HomeworkIsValide_ShouldUpdateHomework()
        {
            // arrange
            var fixture = new Fixture();
            var homework = fixture.Build<Homework>()
                .Create();


            _homeworkRepositoryMock
                .Setup(x => x.Update(homework))
                .ReturnsAsync(homework.Id);
            // act
            var homeworkId = await _service.Update(homework);

            // assert 
            homeworkId.Should().BeGreaterThan(default);
            _homeworkRepositoryMock.Verify(x => x.Update(homework), Times.Once);
        }

        [Theory]
        [InlineData(null, "Test")]
        [InlineData(null, "")]
        [InlineData(null, " ")]
        [InlineData("Test", null)]
        [InlineData("", null)]
        [InlineData(" ", null)]
        [InlineData("Test", " ")]
        [InlineData("Test", "")]
        [InlineData(" ", "Test")]
        [InlineData("", "Test")]
        public async Task Update_HomeworkIsInvalide_ShouldThrowBusinessExceprion(string title, string description)
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var homework = fixture.Build<Homework>()
                .Create();
            homework.Title = title;
            homework.Description = description;

            // act
            var exceprtion = await Assert.ThrowsAsync<HomeworkException>(() => _service.Update(homework));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<HomeworkException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

            _homeworkRepositoryMock.Verify(x => x.Update(homework), Times.Never);
        }

        [Fact]
        public async Task Update_HomeworkIsINull_ShouldThrowBusinessExceprion()
        {
            // arrange 
            Homework homework = null;

            // act 
            var exceprtion = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Update(homework));

            // assert
            exceprtion.Should().NotBeNull()
                .And.Match<ArgumentNullException>(x => x.ParamName == "homework");

            _homeworkRepositoryMock.Verify(x => x.Update(homework), Times.Never);
        }
    }
}
