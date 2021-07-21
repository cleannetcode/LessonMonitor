using AutoMapper;
using LessonMonitor.Core;

namespace LessonMonitor.API
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Contracts.NewMember, Member>();
            CreateMap<Core.Member, Contracts.Member>().ReverseMap();

            CreateMap<Contracts.NewHomework, Homework>();
            CreateMap<Core.Homework, Contracts.Homework>().ReverseMap();

            CreateMap<Contracts.NewLesson, Lesson>();
            CreateMap<Core.Lesson, Contracts.Lesson>().ReverseMap();

            CreateMap<Contracts.NewQuestion, Question>();
            CreateMap<Core.Question, Contracts.Question>().ReverseMap();
        }
    }
}
