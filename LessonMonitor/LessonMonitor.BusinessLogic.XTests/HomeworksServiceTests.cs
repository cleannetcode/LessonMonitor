using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core;
using LessonMonitor.Core.Exceptions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LessonMonitor.BusinessLogic.XTests
{
	public class HomeworksServiceTests
	{
		private readonly Mock<IHomeworksRepository> _homeworksRespositoryMock;
		private readonly HomeworksService _service;

		public HomeworksServiceTests()
		{
			_homeworksRespositoryMock = new Mock<IHomeworksRepository>();
			_service = new HomeworksService(_homeworksRespositoryMock.Object);
		}

		[Fact]
		public async Task Create_HomeworkIsValid_ShouldCreateNewHomework()
		{
			// arrange - подготавливаем данные
			var fixture = new Fixture();

			var expectedHomeworkId = fixture.Create<int>();

			var homework = fixture.Build<Homework>()
				.Without(x => x.MentorId)
				.Create();

			_homeworksRespositoryMock.Setup(x => x.Add(homework))
				.ReturnsAsync(expectedHomeworkId);

			// act - запускаем тестируемый метод
			var result = await _service.Create(homework);

			// assert - проверяем/валидируем результаты теста
			result.Should().Be(expectedHomeworkId);
			_homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Once);
		}

		[Fact]
		public async Task Create_HomeworkIsNull_ShouldThrowArgumentNullException()
		{
			// arrange
			Homework homework = null;

			// act
			await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(homework));

			// assert
			_homeworksRespositoryMock.Verify(x => x.Add(It.IsAny<Homework>()), Times.Never);
		}

		[Theory]
		[InlineData(null, "Test Title")]
		[InlineData("https://github.com/cleannetcode/LessonMonitor", "")]
		[InlineData("https://github.com/cleannetcode/LessonMonitor", null)]
		[InlineData("https://github.com/cleannetcode/LessonMonitor", " ")]
		[InlineData(null, "")]
		[InlineData(null, " ")]
		[InlineData(null, null)]
		public async Task Create_HomeworkIsInvalid_ShouldThrowBusinessException(string link, string title)
		{
			// arrange
			var homework = new Homework();
			homework.Link = link == null ? null : new Uri(link);
			homework.Title = title;

			// act
			var exception = await Assert.ThrowsAsync<BusinessException>(() => _service.Create(homework));

			// assert
			exception.Should().NotBeNull()
				.And
				.Match<BusinessException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

			_homeworksRespositoryMock.Verify(x => x.Add(It.IsAny<Homework>()), Times.Never);
		}

		[Fact]
		public async Task Delete_ShouldDeleteHomework()
		{
			// arrange
			var fixture = new Fixture();
			var homeworkId = fixture.Create<int>();

			// act
			var result = await _service.Delete(homeworkId);

			// assert
			result.Should().BeTrue();
			_homeworksRespositoryMock.Verify(x => x.Delete(homeworkId), Times.Once);
		}

		[Fact]
		public async Task Delete_HomeworkIdIsDefault_ShouldThrowArgumentException()
		{
			// arrange
			// act
			await Assert.ThrowsAsync<ArgumentException>(() => _service.Delete(default));

			// assert
			_homeworksRespositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
		}
	}
}
