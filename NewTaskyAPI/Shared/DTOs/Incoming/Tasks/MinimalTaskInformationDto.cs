using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTaskyAPI.Shared.DTOs.Incoming.Tasks
{
    public class MinimalTaskInformationDto
    {
        public int TaskId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
