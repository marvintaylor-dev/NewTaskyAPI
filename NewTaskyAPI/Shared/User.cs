using Microsoft.AspNetCore.Identity;

namespace NewTaskyAPI.Shared
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public List<Organization>? Organizations { get; set; }
    }
}
