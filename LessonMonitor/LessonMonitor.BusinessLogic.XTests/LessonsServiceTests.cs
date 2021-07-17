using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Moq;
using Xunit;

namespace LessonMonitor.BusinessLogic.XTests
{
    public class LessonsServiceTests
    {
        [Fact]
        public async Task Create_LessonIsValid_ShouldCreateNewLesson()
        {
            // arrange
            var fixture = new Fixture();
            var expectedLessonId = fixture.Create<int>();
            var newLesson = fixture.Create<Lesson>();

            var lessonsRepositoryMock = new Mock<ILessonsRepository>();
            var service = new LessonsService(lessonsRepositoryMock.Object);

            lessonsRepositoryMock
                .Setup(x => x.Add(newLesson))
                .ReturnsAsync(expectedLessonId);

            lessonsRepositoryMock
                .Setup(x => x.Get(newLesson.YouTubeBroadcastId))
                .ReturnsAsync(() => null);

            // act
            var createdLessonId = await service.Create(newLesson);

            // assert
            createdLessonId.Should().Be(expectedLessonId);

            lessonsRepositoryMock.Verify(x => x.Add(newLesson), Times.Once);
            lessonsRepositoryMock.Verify(x => x.Get(newLesson.YouTubeBroadcastId), Times.Once);
        }
    }
}
