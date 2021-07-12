using AutoMapper;

namespace LessonMonitor.DataAccess.MSSQL.MapperConfigurations
{
    public class DataAccessMapperProfile : Profile
    {
        public DataAccessMapperProfile()
        {
            CreateMap<Core.Member, Entities.Member>().ReverseMap();
            CreateMap<Core.Homework, Entities.Homework>().ReverseMap();
        }
    }
}
