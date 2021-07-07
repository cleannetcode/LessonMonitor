//using AutoFixture;
//using FluentAssertions;
//using LessonMonitor.Core.Exceprions;
//using LessonMonitor.Core.Repositories;
//using Moq;
//using NUnit.Framework;
//using System;
//using LessonMonitor.Core.CoreModels;
//using System.Threading.Tasks;

//namespace LessonMonitor.BussinesLogic.NTests
//{
//    public class HomeworksServiceNTests
//    {
//        private Mock<IHomeworksRepository> _homeworkRepositoryMock;
//        private HomeworksService _service;

//        public HomeworksServiceNTests() {}

//        [SetUp]
//        public void SetUp()
//        {
//            _homeworkRepositoryMock = new Mock<IHomeworksRepository>();
//            _service = new HomeworksService(_homeworkRepositoryMock.Object);
//        }

//        [Test]
//        public async Task Create_HomeworkIsValide_ShouldCreateNewHomework()
//        {
//            // arrange
//            var fixture = new Fixture();

//            var expectedHomeworkId = fixture.Create<int>();

//            var homework = fixture.Build<Homework>().Create();

//            _homeworkRepositoryMock.Setup(x => x.Add(homework))
//                .ReturnsAsync(expectedHomeworkId);

//            // act - запускаем тестируемый метод
//            var result = await _service.Create(homework);

//            // assert - проверяем/валидируем результаты теста
//            result.Should().Be(expectedHomeworkId);
//            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Once);
//        }

//        [Test]
//        public void Create_HomeworkIsNull_ShouldThrowArgumentNullException()
//        {
//            // arrange 
//            Homework homework = null;

//            // act 
//            Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(homework));

//            // assert
//            _homeworkRepositoryMock.Verify(x => x.Add(It.IsAny<Homework>()), Times.Never);
//        }

//        [TestCase(null, "Test")]
//        [TestCase(null, "")]
//        [TestCase(null, " ")]
//        [TestCase("Test", null)]
//        [TestCase("", null)]
//        [TestCase(" ", null)]
//        [TestCase("Test", " ")]
//        [TestCase("Test", "")]
//        [TestCase(" ", "Test")]
//        [TestCase("", "Test")]
//        public void Create_HomeworkIsInvalide_ShouldThrowBusinessExceprion(string title, string description)
//        {
//            // arrange
//            var fixture = new Fixture();

//            var homework = fixture.Build<Homework>()
//                .Create();
//            homework.Title = title;
//            homework.Description = description;


//            // act
//            var exceprtion = Assert.ThrowsAsync<HomeworkException>(() => _service.Create(homework));

//            // assert
//            exceprtion.Should().NotBeNull()
//              .And
//              .Match<HomeworkException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

//            _homeworkRepositoryMock.Verify(x => x.Add(It.IsAny<Homework>()), Times.Never);
//        }

//        [Test]
//        public async Task Delete_ShouldDeleteHomework()
//        {
//            // arrange
//            var fixture = new Fixture();

//            var homeworkId = fixture.Create<int>();

//            // act
//            var result = await _service.Delete(homeworkId);

//            // assert
//            result.Should().BeTrue();
//            _homeworkRepositoryMock.Verify(x => x.Delete(homeworkId), Times.Once);
//        }

//        [Test]
//        public void Delete_HomeworkIdisDefault_ShouldHomeworkArgumentException()
//        {
//            // arrange
//            // act
//            Assert.ThrowsAsync<HomeworkException>(() => _service.Delete(default));

//            // assert
//            _homeworkRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
//        }

//        [Test]
//        public async Task Update_HomeworkIsValide_ShouldUpdateHomework()
//        {
//            // arrange - подготавливаем данные
//            var fixture = new Fixture();

//            var homework = fixture.Build<Homework>()
//                .Create();

//            // act - запускаем тестируемый метод
//            var homeworkId = await _service.Update(homework);

//            // assert - проверяем/валидируем результаты теста
//            homeworkId.Should().BePositive();
//            _homeworkRepositoryMock.Verify(x => x.Update(homework), Times.Once);
//        }

//        [TestCase(null, "Test")]
//        [TestCase(null, "")]
//        [TestCase(null, " ")]
//        [TestCase("Test", null)]
//        [TestCase("", null)]
//        [TestCase(" ", null)]
//        public void Update_HomeworkIsInvalide_ShouldThrowBusinessExceprion(int homeworkId)
//        {
//            // arrange - подготавливаем данные
//            var fixture = new Fixture();

//            var homework = fixture.Build<Homework>()
//                .Create();

//            homework.Id = homeworkId;

//            // act
//            bool result = false;

//            var exceprtion = Assert.Throws<HomeworkException>(() => result = _service.Update(homework).Result > 0);

//            // assert
//            exceprtion.Should().NotBeNull()
//              .And
//              .Match<HomeworkException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

//            result.Should().BeFalse();
//            _homeworkRepositoryMock.Verify(x => x.Update(homework), Times.Never);
//        }

//        [Test]
//        public void Update_HomeworkIsINull_ShouldThrowBusinessExceprion()
//        {
//            // arrange 
//            Homework homework = null;

//            // act 
//            bool result = false;

//            var exceprtion = Assert.Throws<ArgumentNullException>(() => result = _service.Update(homework).Result > 0);

//            // assert
//            exceprtion.Should().NotBeNull()
//                .And.Match<ArgumentNullException>(x => x.ParamName == "homework");

//            result.Should().BeFalse();
//            _homeworkRepositoryMock.Verify(x => x.Update(homework), Times.Never);
//        }
//    }
//}
