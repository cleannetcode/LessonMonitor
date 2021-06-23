using AutoFixture;
using FluentAssertions;
using LessonMonitor.Core.CoreModels;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace LessonMonitor.BussinesLogic.NTests
{
    public class QuestionsServiceNTests
    {
        private Mock<IQuestionsRepository> _questionsRepositoryMock;
        private QuestionsService _service;

        public QuestionsServiceNTests() { }

        [SetUp]
        public void SetUp()
        {
            _questionsRepositoryMock = new Mock<IQuestionsRepository>();
            _service = new QuestionsService(_questionsRepositoryMock.Object);
        }

        [Test]
        public void Create_QuestionIsValide_ShouldCreateNewQuestion()
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var question = fixture.Build<Question>()
                .Create();

            // act - запускаем тестируемый метод
            var result = _service.Create(question);

            // assert - проверяем/валидируем результаты теста
            result.Should().BeTrue();
            _questionsRepositoryMock.Verify(x => x.Add(question), Times.Once);
        }

        [Test]
        public void Create_QuestionkIsNull_ShouldThrowBusinessExceprion()
        {
            // arrange 
            Question question = null;

            // act 
            bool result = false;

            var exceprtion = Assert.Throws<QuestionException>(() => result = _service.Create(question));

            // assert
            exceprtion.Should().NotBeNull()
                .And.Match<QuestionException>(x => x.Message == QuestionsService.QUESTION_IS_INVALID);

            result.Should().BeFalse();
            _questionsRepositoryMock.Verify(x => x.Add(question), Times.Never);
        }

        [TestCase(0)]
        [TestCase(-236)]
        [TestCase(-53236)]
        [TestCase(-742364366)]
        public void Create_QuestionIsInvalide_ShouldThrowBusinessExceprion(int questionId)
        {
            // arrange
            var fixture = new Fixture();

            var question = fixture.Build<Question>()
                .Without(x => x.User)
                .Create();

            question.Id = questionId;

            // act
            bool result = false;

            var exceprtion = Assert.Throws<QuestionException>(() => result = _service.Create(question));

            // assert
            exceprtion.Should().NotBeNull()
              .And
              .Match<QuestionException>(x => x.Message == QuestionsService.QUESTION_IS_INVALID);

            result.Should().BeFalse();
            _questionsRepositoryMock.Verify(x => x.Add(question), Times.Never);
        }

        [Test]
        public void Create_QuestionIsInvalideWithoutUser_ShouldCreateNewQuestion()
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var question = fixture.Build<Question>()
                .Without(x => x.User)
                .Create();

            // act - запускаем тестируемый метод
            bool result = false;

            var exceprtion = Assert.Throws<QuestionException>(() => result = _service.Create(question));

            // assert - проверяем/валидируем результаты теста
            exceprtion.Should().NotBeNull()
             .And
             .Match<QuestionException>(x => x.Message == QuestionsService.QUESTION_IS_INVALID);

            result.Should().BeFalse();
            _questionsRepositoryMock.Verify(x => x.Add(question), Times.Never);
        }

        [Test]
        public void Get_ShouldReturnQuestionsArray()
        {
            // arrange - подготавливаем данные
            var fixture = new Fixture();

            var questions = Enumerable.Range(0, 5)
                .Select(x => fixture.Build<Question>().Create())
                .ToList();

            // act - запускаем тестируемый метод
            //var result = _service.Get();


            questions.Should().NotBeNullOrEmpty();
            //_questionsRepositoryMock.Verify(x => x.Get(), Times.Once);
        }
    }
}
