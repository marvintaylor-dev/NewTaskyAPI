﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NewTaskyAPI.Shared
{
    public class NoteModel
    {
        //create these properties for the model
        //string SupportingDocuments - may require a many-to-many relationship so that multiple documents can be linked to multiple tasks and tasks can be assigned more than one document.
        //ID for product backlog - will allow users to have multiple products within their account
        //ID for organization - will separate one organization's account from others.
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public int? Order { get; set; }

        [ForeignKey(nameof(UserStoryId))]
        public int? UserStoryId { get; set; }

        public UserStory? UserStory { get; set; }

        public string AcceptanceCriteria { get; set; } = string.Empty;


        [ForeignKey("MemberId")]
        public int Assignee { get; set; }

        [ForeignKey(nameof(EpicId))]
        public int? EpicId { get; set; } 

        //Navigation Property
        public Epic? Epic { get; set; }

        [ForeignKey("TagId")]
        public int? Tag { get; set; }

        public Priority PriorityLevel { get; set; } = Priority.None;

        [ForeignKey("EstimationId")]
        public int? SizeEstimate { get; set; }

        public int VisualHeightOfTask { get; set; } = 0;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateModified { get; set;} = DateTime.Now;

        public DateTime? DateBeganProcess { get; set; }
        public DateTime? DateItemLeftProcess { get; set; }


        [ForeignKey("StatusId")]
        public int? Status { get; set; }

        [JsonIgnore]
        public List<SprintModel>? AssignedToSprint { get; set; }
        public List<TasksSprints>? TasksSprints { get; set; }

        public bool? isSubTask { get; set; } = false;

        // public bool? recurringTask { get; set; } 

        public int? LinkTo { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public int ProjectId { get; set; }
        [ForeignKey(nameof(OrganizationId))]

        public Guid OrganizationId { get; set; }

    }

}
