using LessonMonitor.Core.CoreModels;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositories
{
    public interface IMembersRepository
    {
        Task<int> Add(Member newMember);
        Task<bool> Delete(int memberId);
        Task<Member> Get(int memberId);
        Task<Member[]> Get();
        Task<int> Update(Member member);
    }
}