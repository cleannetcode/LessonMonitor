using AutoFixture;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace LessonMonitor.DataAccess.MSSQL.XTests
{
    public class QuestionsRepositoryXTests
    {
        private LMonitorDbContext _context;
        private QuestionsRepository _repository;

        public QuestionsRepositoryXTests() 
        {
            var optionsBuilder = new DbContextOptionsBuilder<LMonitorDbContext>();

            var options = optionsBuilder
                    .UseSqlServer(@"Data Source=ASHTON\ASHTON;Initial Catalog=LessonMonitorDbMainTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                    .Options;

            _context = new LMonitorDbContext(options);

            _repository = new QuestionsRepository(_context);
        }

        [Fact]
        public async Task Add_ValidQuestion_ShouldCreateNewQuestion()
        {
            // arrange
            var fixture = new Fixture();
            var question = fixture.Build<Core.CoreModels.Question>().Create();
            question.MemberId = 1;

            // act
            var questionId = await _repository.Add(question);

            // assert
            Assert.True(questionId > 0);
        }

        [Fact]
        public async Task Get()
        {
            // arrange\
            var fixture = new Fixture();

            for (int i = 0; i < 10; i++)
            {
                var question = fixture.Build<Core.CoreModels.Question>().Create();
                question.MemberId = 1;

                var questionId = await _repository.Add(question);
            }

            // act
            var questions = await _repository.Get();

            // assert
            Assert.NotNull(questions);
            Assert.NotEmpty(questions);
        }

        [Fact]
        public async Task GetMQuestionWithId_ShuldReturnQuestionWithUser()
        {
            // arrange
            var fixture = new Fixture();
            var question = fixture.Build<Core.CoreModels.Question>().Create();
            question.MemberId = 1;

            // act
            var questionId = await _repository.Add(question);
            var questionGetted = await _repository.Get(questionId);

            // assert
            Assert.NotNull(questionGetted);
        }

        [Fact]
        public async Task Delete()
        {
            var fixture = new Fixture();
            var question = fixture.Build<Core.CoreModels.Question>().Create();
            question.MemberId = 1;

            // act
            var questionId = await _repository.Add(question);
            var result = await _repository.Delete(questionId);
            var questionGettedGetted = await _repository.Get(questionId);

            // assert
            Assert.True(result);
            Assert.Null(questionGettedGetted);
        }
    }
}
