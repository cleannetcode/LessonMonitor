using AutoFixture;
using LessonMonitor.Core;
using System;
using Xunit;

namespace LessonMonitor.DataAccess.Tests
{
	public class HomeworksRepositoryTests : IDisposable
	{
		private HomeworksRepository _repository;

		public HomeworksRepositoryTests()
		{
			var connectionString = "Server=localhost;Database=LessonMonitorTestDb;Integrated Security=true;";
			_repository = new HomeworksRepository(connectionString);
		}

		[Fact]
        public void Add_ValidHomework_ShouldCreateNewHomework()
        {
			// arrange
			var fixture = new Fixture();
			var homework = fixture.Create<Homework>();

			// act
			var homeworkId = _repository.Add(homework);

			// assert
			Assert.True(homeworkId > 0);
		}

		[Fact]
		public void Update()
		{
			var fixture = new Fixture();
			var newhomework = fixture.Create<Homework>();

			var homeworkId = _repository.Add(newhomework);

			var updatedhomework = fixture.Create<Homework>();
			updatedhomework.Id = homeworkId;

			// act
			_repository.Update(updatedhomework);

			// assert
			var homework = _repository.Get(homeworkId);
			Assert.NotNull(homework);
			Assert.Equal(updatedhomework.Title, homework.Title);
			Assert.Equal(updatedhomework.Description, homework.Description);
			Assert.Equal(updatedhomework.Link, homework.Link);
		}

		[Fact]
		public void Get()
		{
			var fixture = new Fixture();

			for (int i = 0; i < 10; i++)
			{
				var newhomework = fixture.Create<Homework>();
				_repository.Add(newhomework);
			}

			// act
			var homeworks = _repository.Get();

			// assert
			Assert.NotNull(homeworks);
			Assert.NotEmpty(homeworks);
		}

		[Fact]
		public void GetWithHomeworkId()
		{
			var fixture = new Fixture();
			var newhomework = fixture.Create<Homework>();
			var homeworkId = _repository.Add(newhomework);

			// act
			var homework = _repository.Get(homeworkId);

			// assert
			Assert.NotNull(homework);
		}

		[Fact]
		public void Delete()
		{
			var fixture = new Fixture();
			var newhomework = fixture.Create<Homework>();

			var homeworkId = _repository.Add(newhomework);

			// act
			_repository.Delete(homeworkId);

			// assert
			var homework = _repository.Get(homeworkId);
			Assert.Null(homework);
		}

		public void Dispose()
		{
			_repository.CleanTable();
		}
	}
}
