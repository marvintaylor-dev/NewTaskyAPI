using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewTaskyAPI.Shared
{ 
    public class Epic
    {
        [Key]
        public int EpicId { get; set; }
        public string EpicName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(8, 2)")]
        [Range(0.0, (double)decimal.MaxValue, ErrorMessage = "Your number is negative or is not within range.")]

        public decimal EpicBudget { get; set; } = decimal.Zero;
        [Range(0,9,ErrorMessage = "The value must be between 0 and 9.")]
        public TagColor? EpicColor { get; set; } = TagColor.Default;

        public string EpicCategory { get; set; } = string.Empty;

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        //public User? CreatedBy { get; set; }
        //public User? UpdatedBy { get; set; }

        //navigation property
        public IList<NoteModel>? UserStoriesInEpic { get; set; }

        [ForeignKey(nameof(ProjectId))]

        public int ProjectId { get; set; }
        [ForeignKey(nameof(OrganizationId))]

        public Guid OrganizationId { get; set; }

    }
}
