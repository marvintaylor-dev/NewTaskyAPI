using AutoMapper;
using NewTaskyAPI.Shared;
using NewTaskyAPI.Shared.DTOs;
using NewTaskyAPI.Shared.DTOs.Incoming.Tasks;

namespace NewTaskyAPI.Server.AutoMapperProfiles
{
    public class NoteModelProfile : Profile
    {

        public NoteModelProfile()
        {
            CreateMap<NoteModel, NoteModel>();
                //.ForMember(dest => dest.AssignedToSprint, opt => opt.Ignore());
            CreateMap<NoteModel, MinimalTaskInformationDto>().ReverseMap();
        }
    }
}
