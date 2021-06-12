using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core;
using LessonMonitor.Core.Exceptions;
using Moq;
using System;
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

		// unit testing name patterns
		// MethodName_Conditions_Result
		[Fact]
		public void Create_HomeworkIsValid_ShouldCreateNewHomework()
		{
			// arrange - подготавливаем данные
			var fixture = new Fixture();

			var homework = fixture.Build<Homework>()
				.Without(x => x.MentorId)
				.Create();

			// act - запускаем тестируемый метод
			var result = _service.Create(homework);

			// assert - проверяем/валидируем результаты теста
			result.Should().BeTrue();
			_homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Once);
		}

		[Fact]
		public void Create_HomeworkIsNull_ShouldThrowArgumentNullException()
		{
			// arrange
			Homework homework = null;

			// act
			bool result = false;
			var exception = Assert.Throws<ArgumentNullException>(() => result = _service.Create(homework));

			// assert
			exception.Should().NotBeNull()
				.And
				.Match<ArgumentNullException>(x => x.ParamName == "homework");

			result.Should().BeFalse();
			_homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Never);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-236)]
		[InlineData(-53236)]
		[InlineData(-742364366)]
		public void Create_HomeworkIsInvalid_ShouldThrowBusinessException(int memberId)
		{
			// arrange
			var homework = new Homework();
			homework.MemberId = memberId;

			// act
			bool result = false;
			var exception = Assert.Throws<BusinessException>(() => result = _service.Create(homework));

			// assert
			exception.Should().NotBeNull()
				.And
				.Match<BusinessException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);

			result.Should().BeFalse();
			_homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Never);
		}

		[Fact]
		public void Delete_ShouldDeleteHomework()
		{
			// arrange
			var fixture = new Fixture();
			var homeworkId = fixture.Create<int>();

			// act
			var result = _service.Delete(homeworkId);

			// assert
			result.Should().BeTrue();
			_homeworksRespositoryMock.Verify(x => x.Delete(homeworkId), Times.Once);
		}
	}
}
