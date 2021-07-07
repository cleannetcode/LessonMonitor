using AutoFixture;
using LessonMonitor.Core.CoreModels;
using NUnit.Framework;
using System.Linq;

namespace LessonMonitor.DataAccess.NTests
{
    public class QuestionsRepositoryNTests
	{
  //      private QuestionsRepository _repository;
  //      public QuestionsRepositoryNTests() { }

  //      [SetUp]
  //      public void SetUp()
  //      {
		//	_repository = new QuestionsRepository();
		//}

		//[Test]
		//public void Add_ValidQuestion_ShouldCreateNewQuestion()
		//{
		//	// arrange
		//	var fixture = new Fixture();
		//	var question = fixture.Build<Core.CoreModels.Question>().Create();
		//	question.User.Id = 11;

		//	// act
		//	var questionId = _repository.Add(question).Result;

		//	// assert
		//	Assert.True(questionId > 0);
		//}

		//[Test]
		//public void Update()
		//{
		//	// arrange
		//	var fixture = new Fixture();
		//	var newQuestion = fixture.Build<Core.CoreModels.Question>().Create();
		//	newQuestion.User.Id = 11;

		//	var questionId = _repository.Add(newQuestion).Result;

		//	var updatedQuestion = fixture.Build<Question>().Create();
		//	updatedQuestion.User.Id = 11;

		//	updatedQuestion.Id = questionId;

		//	// act
		//	var result = _repository.Update(updatedQuestion).Result;

		//	// assert
		//	var question = _repository.Get(questionId).Result;

		//	Assert.IsTrue(result);
		//	Assert.NotNull(question);
		//	Assert.AreEqual(updatedQuestion.Id, question.Id);
		//	Assert.AreEqual(updatedQuestion.Description, question.Description);
		//}

		//[Test]
		//public void Get()
		//{
		//	// arrange\
		//	var fixture = new Fixture();

		//	for (int i = 0; i < 10; i++)
		//	{
		//		var question = fixture.Build<Question>().Create();

		//		question.User.Id = 11;

		//		var questinId = _repository.Add(question).Result;
		//	}

		//	// act
		//	var questions = _repository.Get().Result;

		//	// assert
		//	Assert.NotNull(questions);
		//	Assert.IsNotEmpty(questions);
		//}

		//[Test]
		//public void GetFullQuestionWithId_ShuldReturnQuestionWithUser()
		//{
		//	// arrange
		//	var fixture = new Fixture();
		//	var newQuestion = fixture.Build<Question>().Create();
		//	newQuestion.User.Id = 11;

		//	// act
		//	var questionId = _repository.Add(newQuestion).Result;
		//	var question = _repository.GetFullEntities(questionId).Result;

		//	// assert
		//	Assert.NotNull(question);
		//	Assert.NotNull(question.User);
		//}

		//[Test]
		//public void Delete()
		//{
		//	var fixture = new Fixture();
		//	var newQuestion = fixture.Build<Question>().Create();
		//	newQuestion.User.Id = 11;


		//	// act
		//	var questionId = _repository.Add(newQuestion).Result;
		//	var result = _repository.Delete(questionId).Result;
		//	var question = _repository.Get(questionId).Result;

		//	// assert
		//	Assert.IsTrue(result);
		//	Assert.Null(question);
		//}
	}
}
