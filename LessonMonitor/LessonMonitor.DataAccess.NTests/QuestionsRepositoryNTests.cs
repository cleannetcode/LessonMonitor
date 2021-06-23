using AutoFixture;
using LessonMonitor.Core.CoreModels;
using LessonMonitor.DataAccess.Repositories;
using NUnit.Framework;
using System.Linq;

namespace LessonMonitor.DataAccess.NTests
{
    public class QuestionsRepositoryNTests
	{
        private QuestionsRepository _repository;
        public QuestionsRepositoryNTests() { }

        [SetUp]
        public void SetUp()
        {
            var connectionString = @"Data Source=ASHTON\ASHTON;Initial Catalog=LessonMonitorTestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _repository = new QuestionsRepository(connectionString);
		}

		[Test]
		public void Add_ValidQuestion_ShouldCreateNewQuestion()
		{
			// arrange
			var fixture = new Fixture();
			var question = fixture.Build<Question>().Create();
			question.User.Id = 11;

			// act
			var questionId = _repository.Add(question);

			// assert
			Assert.True(questionId > 0);
		}

		[Test]
		public void Update()
		{
			// arrange
			var fixture = new Fixture();
			var newQuestion = fixture.Build<Question>().Create();
			newQuestion.User.Id = 11;
			var questionId = _repository.Add(newQuestion);
			var updatedQuestion = fixture.Build<Question>().Create();
			updatedQuestion.User.Id = 11;

			updatedQuestion.Id = questionId;

			// act
			_repository.Update(updatedQuestion);

			// assert
			var question = _repository.Get(questionId);

			Assert.NotNull(question);
			Assert.AreEqual(updatedQuestion.Id, question.Id);
			Assert.AreEqual(updatedQuestion.Description, question.Description);
		}

		[Test]
		public void Get()
		{
			// arrange\
			var fixture = new Fixture();

			for (int i = 0; i < 10; i++)
			{
				var question = fixture.Build<Question>().Create();

				question.User.Id = 11;

				_repository.Add(question);
			}

			// act
			var questions = _repository.Get();

			// assert
			Assert.NotNull(questions);
			Assert.NotNull(questions.FirstOrDefault().User);
			Assert.IsNotEmpty(questions);
		}

		[Test]
		public void GetWithQuestionId()
		{
			// arrange
			var fixture = new Fixture();
			var newQuestion = fixture.Build<Question>().Create();
			newQuestion.User.Id = 11;
			var questionId = _repository.Add(newQuestion);

			// act
			var question = _repository.Get(questionId);

			// assert
			Assert.NotNull(question);
			Assert.NotNull(question.User);
		}

		[Test]
		public void Delete()
		{
			var fixture = new Fixture();
			var newQuestion = fixture.Build<Question>().Create();
			newQuestion.User.Id = 11;
			var questionId = _repository.Add(newQuestion);

			// act
			_repository.Delete(questionId);

			// assert
			var question = _repository.Get(questionId);

			Assert.Null(question);
		}

		[TearDown]
		public void DeleteTestData()
		{
			_repository.CleanTable();
		}
	}
}
