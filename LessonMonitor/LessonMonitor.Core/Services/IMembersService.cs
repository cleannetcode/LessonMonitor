using System.Threading.Tasks;

namespace LessonMonitor.Core.Services
{
    public interface IMembersService
    {
        Task<int> Create(Member newMember);

        Task<Member[]> Get();

        Task<Member> Get(string youtubeUserId);

        Task<MemberHomework[]> GetHomeworks(int memberId);

        Task<MemberStatistic[]> GetStatistics(int memberId);
    }
}
