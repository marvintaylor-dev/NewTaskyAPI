using NewTaskyAPI.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTaskyAPI.Shared.DTOs.Outgoing.ProductGoal
{
    public class GetProductGoalDto : BaseProductGoalDto
    {
        public int ProductGoalId { get; set; }

        
        [ForeignKey(nameof(OrganizationId))]

        public Guid OrganizationId { get; set; }
    }
}
