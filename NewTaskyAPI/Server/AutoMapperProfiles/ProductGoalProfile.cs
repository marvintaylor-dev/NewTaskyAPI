using NewTaskyAPI.Shared.DTOs.Incoming.Tasks;
using NewTaskyAPI.Shared;
using NewTaskyAPI.Shared.DTOs.Outgoing.ProductGoal;
using NewTaskyAPI.Shared.DTOs.Incoming.ProductGoal;
using AutoMapper;

namespace NewTaskyAPI.Server.AutoMapperProfiles
{
    public class ProductGoalProfile : Profile
    {
        public ProductGoalProfile()
        {
            CreateMap<GetProductGoalDto, ProductGoal>().ReverseMap();
            CreateMap<CreateProductGoalDto, ProductGoal>().ReverseMap();
            CreateMap<UpdateProductGoalsDto, ProductGoal>().ReverseMap();
        }
    }
}
