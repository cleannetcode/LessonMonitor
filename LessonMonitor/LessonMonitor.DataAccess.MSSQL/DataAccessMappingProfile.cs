using AutoMapper;
using LessonMonitor.Core;
using LessonMonitor.DataAccess.MSSQL.Entities;

namespace LessonMonitor.DataAccess.MSSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Core.Member, Entities.Member>().ReverseMap();
            CreateMap<Core.Lesson, Entities.Lesson>().ReverseMap();

            CreateMap<Entities.Member, Core.MemberStatistic[]>()
                .ConvertUsing(new MemberStatisticConverter());

            CreateMap<Entities.GithubAccount, Core.GitHubAccount>();
        }
    }
}
