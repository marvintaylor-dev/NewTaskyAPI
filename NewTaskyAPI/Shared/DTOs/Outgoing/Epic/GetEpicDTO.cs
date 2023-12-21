
using NewTaskyAPI.Shared.DTOs.Incoming.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NewTaskyAPI.Shared.DTOs.Outgoing.Epic
{
    public class GetEpicDTO
    { 
        public int EpicId { get; set; }
        public string EpicName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(8, 2)")]

        public decimal EpicBudget { get; set; } = decimal.Zero;
        public TagColor? EpicColor { get; set; } = TagColor.Warning;
        public string EpicCategory { get; set; } = string.Empty;
        //navigation property
        public IList<MinimalTaskInformationDto>? UserStoriesInEpic { get; set; }

    }
}
