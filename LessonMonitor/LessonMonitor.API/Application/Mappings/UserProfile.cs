using AutoMapper;
using LessonMonitor.API.Application.DTOs;
using LessonMonitor.API.Domain;

namespace LessonMonitor.API.Application.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpRequest, UserDTO>();
            CreateMap<User, UserDTO>();
        }
        
    }
}
