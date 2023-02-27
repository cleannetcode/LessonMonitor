using Moq;
using AutoFixture;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Models;
using LessonMonitor.Core.Exceptions;

namespace LessonMonitor.BusinessLogic.MSTests
{
    [TestClass]
    public class HomeworkServiceTests
    {
        private readonly Mock<IHomeworkRepository> _homeworkRepositoryMock;
        private readonly HomeworkService _service;

        public HomeworkServiceTests()
        {
            _homeworkRepositoryMock = new Mock<IHomeworkRepository>();
            _service = new HomeworkService(_homeworkRepositoryMock.Object);
        }

        [TestMethod]
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

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-10000)]
        public void Create_HomeworkIsInvalid_ShouldThrowBusinessException(int memberId)
        {
            var homework = new Homework();
            homework.MemberId = memberId;

            object result = null;
            var exception = Assert.ThrowsException<BusinessException>(() => result = _service.Create(homework));
            
            Assert.IsNull(result);
            Assert.IsNotNull(exception);
            Assert.AreEqual(typeof(BusinessException), exception.GetType());
            Assert.AreEqual(HomeworkService.HOMEWORK_IS_INVALID, exception.Message);
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [TestMethod]
        public void Create_HomeworkIsNull_ShouldThrowArgumentNullException()
        {
            Homework homework = null;
            // act
            object result = null;
            var exception = Assert.ThrowsException<ArgumentNullException>(() => result = _service.Create(homework));
            // assert
            Assert.IsNull(result);
            Assert.IsNotNull(exception);
            Assert.AreEqual(typeof(ArgumentNullException), exception.GetType());
            Assert.AreEqual(nameof(homework), exception.ParamName);
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [TestMethod]
        public void Delete_ShouldDeleteHomework()
        {
            var homeworkId = 1;

            var result = _service.Delete(homeworkId);

            Assert.IsTrue(result);
            _homeworkRepositoryMock.Verify(x => x.Delete(homeworkId), Times.Once());
        }
    }
}