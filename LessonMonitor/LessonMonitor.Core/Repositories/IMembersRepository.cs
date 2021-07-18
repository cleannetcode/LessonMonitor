using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositories
{
    public interface IMembersRepository
    {
        Task<int> Add(Member newMember);

        Task<Member[]> Get();

        Task<Member> Get(string youTubeUserId);

        Task<MemberStatistic[]> GetStatistics(int memberId);

        Task Update(Member member);
    }
}
