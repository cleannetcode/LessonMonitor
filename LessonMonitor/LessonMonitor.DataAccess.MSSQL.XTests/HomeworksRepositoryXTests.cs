using AutoFixture;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace LessonMonitor.DataAccess.MSSQL.XTests
{
    public class HomeworksRepositoryXTests
    {
        private LMonitorDbContext _context;
        private HomeworksRepository _repository;

        public HomeworksRepositoryXTests() 
        {
            var optionsBuilder = new DbContextOptionsBuilder<LMonitorDbContext>();

            var options = optionsBuilder
                    .UseSqlServer(@"Data Source=ASHTON\ASHTON;Initial Catalog=LessonMonitorDbMainTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                    .Options;

            _context = new LMonitorDbContext(options);

            _repository = new HomeworksRepository(_context);
        }

        [Fact]
        public async Task Add_ValidHomework_ShouldCreateNewHomework()
        {
            // arrange
            var fixture = new Fixture();
            var homework = fixture.Build<Core.CoreModels.Homework>().Create();
            homework.LessonId = 1;
            
            // act
            var homeworkId = await _repository.Add(homework);

            // assert
            Assert.True(homeworkId > 0);
        }

        [Fact]
        public async Task Update()
        {
            // arrange
            var fixture = new Fixture();
            var homework = fixture.Build<Core.CoreModels.Homework>().Create();
            homework.LessonId = 1;

            var homeworkId = await _repository.Add(homework);

            var updatedHomework = fixture.Build<Core.CoreModels.Homework>().Create();
            updatedHomework.LessonId = 1;
            updatedHomework.Id = homeworkId;

            // act
            var updatedHomeworkId = await _repository.Update(updatedHomework);
            var updatedHomeworkGet = await _repository.Get(updatedHomeworkId);
            // assert
            Assert.Equal(homeworkId, updatedHomeworkGet.Id);
            Assert.NotEqual(updatedHomeworkGet.Title, homework.Title);
            Assert.NotEqual(updatedHomeworkGet.Description, homework.Description);
            Assert.NotEqual(updatedHomeworkGet.Link, homework.Link);
        }

        [Fact]
        public async Task Get()
        {
            // arrange\
            var fixture = new Fixture();

            for (int i = 0; i < 10; i++)
            {
                var homework = fixture.Build<Core.CoreModels.Homework>().Create();
                homework.LessonId = 1;

                var questinId = await _repository.Add(homework);
            }

            // act
            var homeworks = await _repository.Get();

            // assert
            Assert.NotNull(homeworks);
            Assert.NotEmpty(homeworks);
        }

        [Fact]
        public async Task GetHomeworkWithId_ShuldReturnHomeworkWithUser()
        {
            // arrange
            var fixture = new Fixture();
            var homework = fixture.Build<Core.CoreModels.Homework>().Create();
            homework.LessonId = 1;

            // act
            var homeworkId = await _repository.Add(homework);
            var homeworkGetted = await _repository.Get(homeworkId);

            // assert
            Assert.NotNull(homeworkGetted);
        }

        [Fact]
        public async Task Delete()
        {
            var fixture = new Fixture();
            var homework = fixture.Build<Core.CoreModels.Homework>().Create();
            homework.LessonId = 1;


            // act
            var homeworkId = await _repository.Add(homework);
            var result = await _repository.Delete(homeworkId);
            var homeworkGetted = await _repository.Get(homeworkId);

            // assert
            Assert.True(result);
            Assert.Null(homeworkGetted);
        }
    }
}
