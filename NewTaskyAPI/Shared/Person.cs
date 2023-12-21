using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTaskyAPI.Shared
{
    public class Person
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PersonalEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set;}
    }

    public class OrganizationMember : Person
    {
        public Guid MemberId { get; set; }
        public string OrganizationEmail { get; set; }
        public string OrganizationPhoneNumber { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; }
        public List<DateTime>? VacationDates { get; set; }
        public TimeZoneInfo TimeZone { get; set; }

        public int PermissionLevel { get; set; }
        public string RoleOnTeam { get; set; }
        
        public string JobTitle { get; set; } = string.Empty;
        public decimal Compensation { get; set; }
        public int Capacity { get; set; }
        public List<SprintModel>? SprintsAssignedTo { get; set; }
        public int WorkAssigned { get; set; } = 0;
        public List<TimeSpan> ActiveTimes { get; set; }
        public int TeamId { get; set; } = 0;

        public List<int> ProjectIds { get; set; }
        //[ForeignKey(nameof(OrganizationId))]

        //public Guid OrganizationId { get; set; }

    }

    public class UserProfileInformation : Person
    {
        public string ProfilePicture { get; set; }
        public string ThemePreference { get; set; }
        public List<Organization> Organizations { get; set; }
        public List<Project> Projects { get; set; }
    }

    public class GuestClass : Person
    {
        public bool IsGuest { get; set; }
        public string GuestEmail { get; set; }
        public int PermissionLevel { get; set; }
    }

    public class PasswordCredentials : Person
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
