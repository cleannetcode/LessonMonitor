using Moq;
using AutoFixture;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Models;
using LessonMonitor.Core.Exceptions;

namespace LessonMonitor.BL.XUnitTests
{
    public class HomeworkServiceTests
    {
        private readonly Mock<IHomeworkRepository> _homeworkRepositoryMock;
        private readonly HomeworkService _service;

        public HomeworkServiceTests()
        {
            _homeworkRepositoryMock = new Mock<IHomeworkRepository>();
            _service = new HomeworkService(_homeworkRepositoryMock.Object);
        }

        [Fact]
        public void Create_HomeworkIsValid_ShouldCreateNewHomework()
        {
            // arrange
            var fixture = new Fixture();
            var homework = fixture.Build<Homework>()
                .Without(x => x.MentorId)
                .Create();

            // act
            var result = _service.Create(homework);
            // assert
            Assert.NotNull(result);
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Once());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100000)]
        public void Create_HomeworkIsInvalid_ShouldThrowBusinessException(int memberId)
        {
            var homework = new Homework();
            homework.MemberId = memberId;

            object result = null;
            var exception = Assert.Throws<BusinessException>(() => result = _service.Create(homework));

            Assert.Null(result);
            Assert.NotNull(exception);
            Assert.Equal(typeof(BusinessException), exception.GetType());
            Assert.Equal(HomeworkService.HOMEWORK_IS_INVALID, exception.Message);
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [Fact]
        public void Create_HomeworkIsNull_ShouldThrowArgumentNullException()
        {
            Homework homework = null;
            // act
            object result = null;
            var exception = Assert.Throws<ArgumentNullException>(() => result = _service.Create(homework));
            // assert
            Assert.Null(result);
            Assert.NotNull(exception);
            Assert.Equal(typeof(ArgumentNullException), exception.GetType());
            Assert.Equal(nameof(homework), exception.ParamName);
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [Fact]
        public void Delete_ShouldDeleteHomework()
        {
            var homeworkId = 1;

            var result = _service.Delete(homeworkId);

            Assert.True(result);
            _homeworkRepositoryMock.Verify(x => x.Delete(homeworkId), Times.Once());
        }
    }
}