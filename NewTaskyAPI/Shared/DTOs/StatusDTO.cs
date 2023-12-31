﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTaskyAPI.Shared.DTOs
{
    public class StatusDTO
    {
        public int StatusId { get; set; }   
        public string StatusName { get; set; } = string.Empty;
        public string StatusDefinitionOfFinished { get; set; } = string.Empty;
        public int WorkInProgressLimit { get; set; } = 0;
        public int StatusOrder { get; set; }   
        public bool IsEditing { get; set; }
    }
}
