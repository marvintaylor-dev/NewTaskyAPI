using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTaskyAPI.Shared.DTOs.Base
{
    public abstract class BaseProductGoalDto
    {
        [Required]
        public string ProductGoalName { get; set; } = string.Empty;
        public string? Goal_1 { get; set; } = string.Empty;
        public string? Goal_2 { get; set; } = string.Empty;
        public string? Goal_3 { get; set; } = string.Empty;
        public string? Goal_4 { get; set; } = string.Empty;
        public string? Goal_5 { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool? CurrentGoal { get; set; }
        public int? ProjectId { get; set; }
    }
}
