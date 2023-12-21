using AutoMapper;
using NewTaskyAPI.Shared;

namespace NewTaskyAPI.Server.AutoMapperProfiles
{
    public class SprintProfile : Profile
    {
        public SprintProfile()
        {
            CreateMap<SprintModel, SprintModel>();
        }
    }
}
