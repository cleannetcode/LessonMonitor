using AutoFixture;
using LessonMonitor.Core.CoreModels;
using LessonMonitor.DataAccess.Repositories;
using NUnit.Framework;

namespace LessonMonitor.DataAccess.NTests
{
    public class TopicsRepositoryNTests
	{
        private TopicsRepository _repository;
        public TopicsRepositoryNTests() { }

        [SetUp]
        public void SetUp()
        {
			var connectionString = @"Data Source=ASHTON\ASHTON;Initial Catalog=LessonMonitorTestDb;Integrated Security=True;";

			_repository = new TopicsRepository(connectionString);
		}

		[Test]
		public void Add_ValidTopic_ShouldCreateNewUser()
		{
			// arrange
			var fixture = new Fixture();
			var topic = fixture.Build<Topic>().Create();

			// act
			var createdTopicId = _repository.Add(topic);

			// assert
			Assert.True(createdTopicId > 0);
		}

		[Test]
		public void Update()
		{
			// arrange
			var fixture = new Fixture();
			var newTopic = fixture.Build<Topic>().Create();
			var topicId = _repository.Add(newTopic);
			var updatedTopic = fixture.Build<Topic>().Create();
			updatedTopic.Id = topicId;

			// act
			_repository.Update(updatedTopic);

			// assert
			var topic = _repository.Get(topicId);

			Assert.NotNull(topic);
			Assert.AreEqual(updatedTopic.Id, topic.Id);
			Assert.AreEqual(updatedTopic.Theme, topic.Theme);
		}

		[Test]
		public void Get()
		{
			// arrange
			var fixture = new Fixture();

			for (int i = 0; i < 10; i++)
			{
				var topic = fixture.Build<Topic>().Create();

				_repository.Add(topic);
			}

			// act
			var topics = _repository.Get();

			// assert
			Assert.NotNull(topics);
			Assert.IsNotEmpty(topics);
		}

		[Test]
		public void GetWithTopicId()
		{
			// arrange
			var fixture = new Fixture();
			var newTopic = fixture.Build<Topic>().Create();
			var topicId = _repository.Add(newTopic);

			// act
			var topic = _repository.Get(topicId);

			// assert
			Assert.NotNull(topic);
		}

		[Test]
		public void Delete()
		{
			// arrange
			var fixture = new Fixture();
			var newTopic = fixture.Build<Topic>().Create();
			var topicId = _repository.Add(newTopic);

			// act
			_repository.Delete(topicId);

			// assert
			var topic = _repository.Get(topicId);

			Assert.Null(topic);
		}

		[TearDown]
		public void DeleteTestData()
		{
			_repository.CleanTable();
		}
	}
}
