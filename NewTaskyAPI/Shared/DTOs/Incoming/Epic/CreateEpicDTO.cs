using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewTaskyAPI.Shared.DTOs.Incoming.Epic
{
    public class CreateEpicDTO
    {
        [Required]
        public string EpicName { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(8, 2)")]
        [Range(0.0, (double)decimal.MaxValue, ErrorMessage = "Your number is negative or is not within range.")]
        public decimal EpicBudget { get; set; } = decimal.Zero;
        [Range(0, 9, ErrorMessage = "The value must be between 0 and 9.")]


        public TagColor? EpicColor { get; set; } = TagColor.Default;

        public string EpicCategory { get; set; } = string.Empty;

    }
}
