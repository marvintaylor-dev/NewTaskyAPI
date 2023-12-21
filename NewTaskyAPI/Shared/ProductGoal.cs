
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NewTaskyAPI.Shared
{
    public class ProductGoal
    {
        [Key]
        public int ProductGoalId { get; set; }

        public string ProductGoalName { get; set; } = string.Empty;
        //public List<string>? ProductGoals { get; set; } = new List<string>();
        public string? Goal_1 { get; set; } = string.Empty;
        public string? Goal_2 { get; set; } = string.Empty;
        public string? Goal_3 { get; set; } = string.Empty;
        public string? Goal_4 { get; set; } = string.Empty;
        public string? Goal_5 { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;

        public bool? CurrentGoal { get; set; }
        public int? ProjectId { get; set; }
        [ForeignKey(nameof(OrganizationId))]

        public Guid OrganizationId { get; set; }

    }
}
