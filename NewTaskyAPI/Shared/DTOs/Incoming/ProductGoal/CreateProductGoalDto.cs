using NewTaskyAPI.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTaskyAPI.Shared.DTOs.Incoming.ProductGoal
{
    public class CreateProductGoalDto : BaseProductGoalDto
    {
        public Guid OrganizationId { get; set; }
    }
}
