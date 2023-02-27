using Moq;
using AutoFixture;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Models;
using LessonMonitor.Core.Exceptions;

namespace LessonMonitor.BL.NUnitTests
{
    public class HomeworkServiceTests
    {
        private Mock<IHomeworkRepository> _homeworkRepositoryMock;
        private HomeworkService _service;

        [SetUp]
        public void SetUp()
        {
            _homeworkRepositoryMock = new Mock<IHomeworkRepository>();
            _service = new HomeworkService(_homeworkRepositoryMock.Object);
        }

        [Test]
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
            Assert.IsNotNull(result);
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Once());
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100000)]
        public void Create_HomeworkIsInvalid_ShouldThrowBusinessException(int memberId)
        {
            var homework = new Homework();
            homework.MemberId = memberId;

            object result = null;
            var exception = Assert.Throws<BusinessException>(() => result = _service.Create(homework));

            Assert.IsNull(result);
            Assert.IsNotNull(exception);
            Assert.That(exception.GetType(), Is.EqualTo(typeof(BusinessException)));
            Assert.That(exception.Message, Is.EqualTo(HomeworkService.HOMEWORK_IS_INVALID));
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [Test]
        public void Create_HomeworkIsNull_ShouldThrowArgumentNullException()
        {
            Homework homework = null;
            // act
            object result = null;
            var exception = Assert.Throws<ArgumentNullException>(() => result = _service.Create(homework));
            // assert
            Assert.IsNull(result);
            Assert.IsNotNull(exception);
            Assert.That(exception.GetType(), Is.EqualTo(typeof(ArgumentNullException)));
            Assert.That(exception.ParamName, Is.EqualTo(nameof(homework)));
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [Test]
        public void Delete_ShouldDeleteHomework()
        {
            var homeworkId = 1;

            var result = _service.Delete(homeworkId);

            Assert.IsTrue(result);
            _homeworkRepositoryMock.Verify(x => x.Delete(homeworkId), Times.Once());
        }
    }
}