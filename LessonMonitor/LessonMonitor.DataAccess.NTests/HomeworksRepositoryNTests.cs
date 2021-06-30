using AutoFixture;
using LessonMonitor.Core.CoreModels;
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
            var connectionString = @"Data Source=ASHTON\ASHTON;Initial Catalog=LessonMonitorTestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _repository = new HomeworksRepository(connectionString);
		}

		[Test]
		public void Add_ValidHomework_ShouldCreateNewHomework()
		{
			// arrange
			var fixture = new Fixture();
			var homework = fixture.Build<Homework>().Create();
			homework.TopicId = 1;

			// act
			var homeworkId = _repository.Add(homework);

			// assert
			Assert.True(homeworkId > 0);
		}

		[Test]
		public void Update()
		{
			// arrange
			var fixture = new Fixture();
			var HomeworkExistUser = 490;
			var updatedhomework = fixture.Build<Homework>().Create();
			updatedhomework.TopicId = 1;
			updatedhomework.Id = HomeworkExistUser;

			// act
			_repository.Update(updatedhomework);

			// assert
			var homework = _repository.Get(HomeworkExistUser);
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
				var newHomework = fixture.Build<Homework>().Create();

				newHomework.TopicId = 1;

				_repository.Add(newHomework);
			}

			// act
			var homeworks = _repository.Get();

			// assert
			Assert.NotNull(homeworks);
			Assert.NotNull(homeworks.FirstOrDefault().User);
			Assert.NotNull(homeworks.FirstOrDefault().Topic);
			Assert.IsNotEmpty(homeworks);
		}

		[Test]
		public void GetWithHomeworkId()
		{
			// arrange
			var userExisHomework = 490;

			// act
			var homework = _repository.Get(userExisHomework);

			// assert
			Assert.NotNull(homework);
			Assert.NotNull(homework.User);
			Assert.NotNull(homework.Topic);
		}

		[Test]
		public void Delete()
		{
			var fixture = new Fixture();
			var newHomework = fixture.Build<Homework>().Create();
			newHomework.TopicId = 1;
			var homeworkId = _repository.Add(newHomework);
			
			// act
			_repository.Delete(homeworkId);

			// assert
			// вставляем 491 потому что у него есть домашка и признак удалён
			var homework = _repository.Get(491);

			Assert.Null(homework);
		}

		[TearDown]
		public void DeleteTestData()
		{
			_repository.CleanTable();
		}
	}
}
