using AutoFixture;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace LessonMonitor.DataAccess.MSSQL.XTests
{
    public class MembersRepositoryXTests
    {
        private LMonitorDbContext _context;
        private MembersRepository _repository;

        public MembersRepositoryXTests() 
        {
            var optionsBuilder = new DbContextOptionsBuilder<LMonitorDbContext>();

            var options = optionsBuilder
                    .UseSqlServer(@"Data Source=ASHTON\ASHTON;Initial Catalog=LessonMonitorDbMainTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                    .Options;

            _context = new LMonitorDbContext(options);

            _repository = new MembersRepository(_context);
        }

        [Fact]
        public async Task Add_ValidMember_ShouldCreateNewMember()
        {
            // arrange
            var fixture = new Fixture();
            var member = fixture.Build<Core.CoreModels.Member>().Create();
            
            // act
            var memberkId = await _repository.Add(member);

            // assert
            Assert.True(memberkId > 0);
        }

        [Fact]
        public async Task Update()
        {
            // arrange
            var fixture = new Fixture();
            var member = fixture.Build<Core.CoreModels.Member>().Create();

            var memberkId = await _repository.Add(member);

            var updatedMember = fixture.Build<Core.CoreModels.Member>().Create();
            updatedMember.Id = memberkId;

            // act
            var updatedMemberId = await _repository.Update(updatedMember);
            var updatedMemberGet = await _repository.Get(updatedMemberId);
            // assert
            Assert.Equal(memberkId, updatedMemberGet.Id);
            Assert.NotEqual(updatedMemberGet.Name, member.Name);
            Assert.NotEqual(updatedMemberGet.GitHubAccountId, member.GitHubAccountId);
        }

        [Fact]
        public async Task Get()
        {
            // arrange\
            var fixture = new Fixture();

            for (int i = 0; i < 10; i++)
            {
                var member = fixture.Build<Core.CoreModels.Member>().Create();

                var memberId = await _repository.Add(member);
            }

            // act
            var members = await _repository.Get();

            // assert
            Assert.NotNull(members);
            Assert.NotEmpty(members);
        }

        [Fact]
        public async Task GetMemberWithId_ShuldReturnMemberWithUser()
        {
            // arrange
            var fixture = new Fixture();
            var member = fixture.Build<Core.CoreModels.Member>().Create();

            // act
            var memberId = await _repository.Add(member);
            var memberGetted = await _repository.Get(memberId);

            // assert
            Assert.NotNull(memberGetted);
        }

        [Fact]
        public async Task Delete()
        {
            var fixture = new Fixture();
            var member = fixture.Build<Core.CoreModels.Member>().Create();

            // act
            var memberId = await _repository.Add(member);
            var result = await _repository.Delete(memberId);
            var memberGetted = await _repository.Get(memberId);

            // assert
            Assert.True(result);
            Assert.Null(memberGetted);
        }
    }
}
