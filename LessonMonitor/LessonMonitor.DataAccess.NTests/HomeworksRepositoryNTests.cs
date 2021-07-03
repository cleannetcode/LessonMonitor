using AutoFixture;
using FluentAssertions;
using LessonMonitor.DataAccess.Repositories;
using NUnit.Framework;
using System.Linq;

namespace LessonMonitor.DataAccess.NTests
{
    public class HomeworksRepositoryNTests
    {
        private HomeworksRepository _repository;
        public HomeworksRepositoryNTests() { }

        [SetUp]
        public void SetUp()
        {
			_repository = new HomeworksRepository();
		}

		[Test]
		public void Add_ValidHomework_ShouldCreateNewHomework()
		{
			// arrange
			var fixture = new Fixture();
			var homework = fixture.Build<Core.CoreModels.Homework>().Create();
			homework.TopicId = 1;

			// act
			var homeworkId = _repository.Add(homework).Result;

			// assert
			Assert.True(homeworkId > 0);
		}

        [Test]
        public void Add_UserHomework_ShouldCreateUserHomework()
        {
            // arrange
            var fixture = new Fixture();
            var homework = fixture.Build<Core.CoreModels.Homework>().Create();
            homework.TopicId = 1;

            // act
            var homeworkId = _repository.Add(homework).Result;
            var result = _repository.AddHomeworkComplited(homeworkId, 11).Result;

            // assert
            Assert.True(result);
        }

        [Test]
        [TestCase(0, 23)]
        [TestCase(-213, 1244)]
        [TestCase(-213324, 12334)]
        [TestCase(45, 0)]
        [TestCase(112, -156)]
        [TestCase(455, -124545)]
        public void Add_InvalidUserHomework_ShouldCreateUserHomework(int homeworkId, int userId)
        {
            // arrange
            var fixture = new Fixture();
            var homework = fixture.Build<Core.CoreModels.Homework>().Create();
            homework.TopicId = 1;

            // act
            var result = _repository.AddHomeworkComplited(homeworkId, userId).Result;

            // assert
            Assert.False(result);
            result.Should().BeFalse();
        }

        [Test]
        public void Update()
        {
            // arrange
            var fixture = new Fixture();
            var updatedhomework = fixture.Build<Core.CoreModels.Homework>().Create();
            updatedhomework.TopicId = 1;
            updatedhomework.Id = 400;

            // act
            _repository.Update(updatedhomework);

            // assert
            var homework = _repository.Get(updatedhomework.Id).Result;

            Assert.NotNull(homework);
            Assert.AreEqual(updatedhomework.TopicId, homework.TopicId);
            Assert.AreEqual(updatedhomework.Name, homework.Name);
            Assert.AreEqual(updatedhomework.Link, homework.Link);
            Assert.AreEqual(updatedhomework.Grade, homework.Grade);
        }

        [Test]
        public void Get()
        {
            // arrange
            var fixture = new Fixture();

            for (int i = 0; i < 10; i++)
            {
                var newHomework = fixture.Build<Core.CoreModels.Homework>().Create();

                newHomework.TopicId = 1;

               var newHomeworkId = _repository.Add(newHomework);
            }

            // act
            var homeworks = _repository.Get().Result;

            // assert
            Assert.NotNull(homeworks);
            Assert.IsNotEmpty(homeworks);
        }

        [Test]
        public void GetWithHomeworkId()
        {
            // arrange
            var fixture = new Fixture();
            var newHomework = fixture.Build<Core.CoreModels.Homework>().Create();
            newHomework.TopicId = 1;

            var newHomeworkId = _repository.Add(newHomework).Result;
            // act
            var homework = _repository.Get(newHomeworkId).Result;

            // assert
            Assert.NotNull(homework);
        }

        [Test]
        public void GetFullHomeworkArray_ShuldReturnHomeworkWithUserWithTopic()
        {
            // arrange
            var fixture = new Fixture();

            for (int i = 0; i < 10; i++)
            {
                var newHomework = fixture.Build<Core.CoreModels.Homework>().Create();

                newHomework.TopicId = 1;

                var nehomeworkId = _repository.Add(newHomework).Result;
            }

            // act
            var homeworks = _repository.GetComplited().Result;

            // assert
            Assert.NotNull(homeworks);
            Assert.NotNull(homeworks.FirstOrDefault().User);
            Assert.NotNull(homeworks.FirstOrDefault().Topic);
            Assert.IsNotEmpty(homeworks);
        }

        [Test]
        public void GetFullHomeworkWithId_ShuldReturnHomeworkWithUserWithTopic()
        {
            // arrange
            var fixture = new Fixture();
            var newHomework = fixture.Build<Core.CoreModels.Homework>().Create();
            newHomework.TopicId = 1;

            // act
            var newHomeworkId = _repository.Add(newHomework).Result;
            var result = _repository.AddHomeworkComplited(newHomeworkId, 11).Result;
            var homework = _repository.GetComplited(newHomeworkId).Result;

            // assert
            Assert.NotZero(newHomeworkId);
            Assert.True(result);
            Assert.NotNull(homework);
            Assert.NotNull(homework.User);
            Assert.NotNull(homework.Topic);
        }



        [Test]
        public void Delete()
        {
            var fixture = new Fixture();
            var newHomework = fixture.Build<Core.CoreModels.Homework>().Create();
            newHomework.TopicId = 1;

            // act
            var homeworkId = _repository.Add(newHomework).Result;
            _repository.Delete(homeworkId);

            // assert
            var homework = _repository.Get(homeworkId).Result;

            Assert.Null(homework);
        }
    }
}
