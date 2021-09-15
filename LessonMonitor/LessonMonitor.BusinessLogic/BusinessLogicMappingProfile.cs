using AutoMapper;
using LessonMonitor.Core;
using LessonMonitor.Core.GitHub;

namespace LessonMonitor.BusinessLogic
{
    public class BusinessLogicMappingProfile : Profile
    {
        public BusinessLogicMappingProfile()
        {
            CreateMap<PullRequest, MemberHomework>();
        }
    }
}
