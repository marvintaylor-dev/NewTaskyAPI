using AutoMapper;
using NewTaskyAPI.Shared;
using NewTaskyAPI.Shared.DTOs;
using NewTaskyAPI.Shared.DTOs.Incoming.Epic;
using NewTaskyAPI.Shared.DTOs.Outgoing.Epic;

namespace NewTaskyAPI.Server.AutoMapperProfiles
{
    public class EpicProfile : Profile
    {
        public EpicProfile()
        {
            CreateMap<CreateEpicDTO, Epic>().ReverseMap();
            CreateMap<Epic, GetEpicDTO>().ReverseMap();
            CreateMap<UpdateEpicDTO, Epic>().ReverseMap()
                .ForMember(x => x.UserStoriesInEpic, opt => opt.Ignore());
        }
    }
}
