using AutoMapper;

namespace LessonMonitor.API.MappingConfigurations
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Contracts.NewMember, Core.Member>();
            CreateMap<Core.Member, Contracts.Member>().ReverseMap();

            CreateMap<Contracts.NewHomework, Core.Homework>().ReverseMap();
            CreateMap<Core.Homework, Contracts.Homework>().ReverseMap();
        }
    }
}
