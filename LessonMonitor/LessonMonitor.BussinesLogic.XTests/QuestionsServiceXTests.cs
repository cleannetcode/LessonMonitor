using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core.CoreModels;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LessonMonitor.BussinesLogic.XTests
{
    public class QuestionsServiceXTests
    {
        private Mock<IQuestionsRepository> _questionsRepositoryMock;
        private QuestionsService _service;

        public QuestionsServiceXTests()
        {
            _questionsRepositoryMock = new Mock<IQuestionsRepository>();
            _service = new QuestionsService(_questionsRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_QestionIsValide_ShouldCreateNewQestion()
        {
            // arrange
            var fixture = new Fixture();
            var expectedQestionId = fixture.Create<int>();
            var question = fixture.Build<Question>().Create();

            _questionsRepositoryMock.Setup(x => x.Add(question))
                .ReturnsAsync(expectedQestionId);

            // act
            var result = await _service.Create(question);

            // assert
            result.Should().Be(expectedQestionId);
            _questionsRepositoryMock.Verify(x => x.Add(question), Times.Once);
        }

        [Fact]
        public async Task Create_QestionIsNull_ShouldThrowArgumentNullException()
        {
            // arrange 
            Question question = null;

            // act 
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(question));

            // assert
            _questionsRepositoryMock.Verify(x => x.Add(It.IsAny<Question>()), Times.Never);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task Create_QestionIsInvalide_ShouldThrowBusinessExceprion(string description)
        {
            // arrange
            var fixture = new Fixture();
            var question = fixture.Build<Question>()
                .Create();
            question.Description = description;

            // act
            var exceprtion = await Assert.ThrowsAsync<QuestionException>(() => _service.Create(question));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<QuestionException>(x => x.Message == QuestionsService.QUESTION_IS_INVALID);

            _questionsRepositoryMock.Verify(x => x.Add(It.IsAny<Question>()), Times.Never);
        }

        [Fact]
        public async Task Delete_ShouldDeleteQestion()
        {
            // arrange
            var fixture = new Fixture();
            var questionId = fixture.Create<int>();

            //act
            var result = await _service.Delete(questionId);

            // assert
           // result.Should().BeTrue();
            _questionsRepositoryMock.Verify(x => x.Delete(questionId), Times.Once);
        }

        [Fact]
        public async Task Delete_QestionIdisDefault_ShouldQestionArgumentException()
        {
            // arrange
            // act
            await Assert.ThrowsAsync<QuestionException>(() => _service.Delete(default));

            // assert
            _questionsRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-123124)]
        [InlineData(-1)]
        public async Task Get_InvalidQuestionId_ShouldReturnBussinesException(int questionId)
        {
            // arrange
            // act
            var exceprtion = await Assert.ThrowsAsync<QuestionException>(() => _service.Get(questionId));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<QuestionException>(x => x.Message == QuestionsService.QUESTION_IS_INVALID);

            _questionsRepositoryMock.Verify(x => x.Add(It.IsAny<Question>()), Times.Never);
        }

        [Fact]
        public async Task Get_DefaultQuestionId_ShouldReturnBussinesException()
        {
            // arrange
            // act
            var exceprtion = await Assert.ThrowsAsync<QuestionException>(() => _service.Get(default));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<QuestionException>(x => x.Message == QuestionsService.QUESTION_IS_INVALID);

            _questionsRepositoryMock.Verify(x => x.Add(It.IsAny<Question>()), Times.Never);
        }
    }
}
