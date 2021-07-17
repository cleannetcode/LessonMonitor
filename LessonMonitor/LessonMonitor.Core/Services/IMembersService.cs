using System.Threading.Tasks;

namespace LessonMonitor.Core.Services
{
    public interface IMembersService
    {
        Task<int> Create(Member newMember);
        Task<Member[]> Get();
    }
}
