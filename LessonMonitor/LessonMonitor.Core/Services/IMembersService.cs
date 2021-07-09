using LessonMonitor.Core.CoreModels;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Services
{
    public interface IMembersService
    {
        Task<int> Create(Member member);
        Task<bool> Delete(int memberId);
        Task<Member> Get(int memberId);
        Task<Member[]> Get();
        Task<int> Update(Member member);
    }
}