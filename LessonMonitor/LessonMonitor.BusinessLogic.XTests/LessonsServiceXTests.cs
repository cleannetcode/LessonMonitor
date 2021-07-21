using AutoFixture;
using FluentAssertions;
using LessonMonitor.BusinessLogic;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace LessonMonitor.BusinessLogic.XTests
{
    public class LessonsServiceXTests
    {
        private Mock<ILessonsRepository> _lessonsRepositoryMock;
        private LessonsService _service;
        private Fixture _fixture;
        public LessonsServiceXTests()
        {
            _fixture = new Fixture();
            _lessonsRepositoryMock = new Mock<ILessonsRepository>();
            _service = new LessonsService(_lessonsRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_LessonIsValid_ShouldCreateNewLesson()
        {
            //arrange
            var expectedLessonId = _fixture.Create<int>();
            var newLesson = _fixture.Create<Lesson>();

            _lessonsRepositoryMock
                .Setup(x => x.Add(newLesson))
                .ReturnsAsync(expectedLessonId);

            _lessonsRepositoryMock
                   .Setup(x => x.Get(newLesson.YouTubeBroadcastId))
                   .ReturnsAsync(() => null);
            //act
            var createdLessonId = await _service.Create(newLesson);

            //assets
            createdLessonId.Should().Be(expectedLessonId);
            _lessonsRepositoryMock.Verify(x => x.Add(newLesson), Times.Once);
            _lessonsRepositoryMock.Verify(x => x.Get(newLesson.YouTubeBroadcastId), Times.Once);
        }
    }
}
