using NewTaskyAPI.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTaskyAPI.Shared.DTOs.Outgoing.ProductGoal
{
    public class UpdateProductGoalsDto : BaseProductGoalDto
    {
        public int ProductGoalId { get; set; }

    }
}
