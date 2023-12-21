using NewTaskyAPI.Shared.DTOs;
using NewTaskyAPI.Shared;
using AutoMapper;

namespace NewTaskyAPI.Server.AutoMapperProfiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile() 
        {
            CreateMap<Member, MemberDTO>();
            CreateMap<MemberDTO, Member>();
            CreateMap<Member, Member>();
        }
    }
}
