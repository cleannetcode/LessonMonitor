using AutoFixture;
using LessonMonitor.Core;
using System;
using System.Threading.Tasks;
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
        public async Task Add_ValidHomework_ShouldCreateNewHomework()
        {
			// arrange
			var fixture = new Fixture();
			var homework = fixture.Create<Homework>();

			// act
			var homeworkId = await _repository.Add(homework);

			// assert
			Assert.True(homeworkId > 0);
		}

		[Fact]
		public async Task Update()
		{
			var fixture = new Fixture();
			var newhomework = fixture.Create<Homework>();

			var homeworkId = await _repository.Add(newhomework);

			var updatedhomework = fixture.Create<Homework>();
			updatedhomework.Id = homeworkId;

			// act
			await _repository.Update(updatedhomework);

			// assert
			var homework = await _repository.Get(homeworkId);
			Assert.NotNull(homework);
			Assert.Equal(updatedhomework.Title, homework.Title);
			Assert.Equal(updatedhomework.Description, homework.Description);
			Assert.Equal(updatedhomework.Link, homework.Link);
		}

		[Fact]
		public async Task Get()
		{
			var fixture = new Fixture();

			for (int i = 0; i < 10; i++)
			{
				var newhomework = fixture.Create<Homework>();
				await _repository.Add(newhomework);
			}

			// act
			var homeworks = await _repository.Get();

			// assert
			Assert.NotNull(homeworks);
			Assert.NotEmpty(homeworks);
		}

		[Fact]
		public async Task GetWithHomeworkId()
		{
			var fixture = new Fixture();
			var newhomework = fixture.Create<Homework>();
			var homeworkId = await _repository.Add(newhomework);

			// act
			var homework = await _repository.Get(homeworkId);

			// assert
			Assert.NotNull(homework);
		}

		[Fact]
		public async Task Delete()
		{
			var fixture = new Fixture();
			var newhomework = fixture.Create<Homework>();

			var homeworkId = await _repository.Add(newhomework);

			// act
			await _repository.Delete(homeworkId);

			// assert
			var homework = await _repository.Get(homeworkId);
			Assert.Null(homework);
		}

		public void Dispose()
		{
			_repository.CleanTable();
		}
	}
}
