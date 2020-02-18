using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Domain.Entities
{
    // Add profile data for application users by adding properties to this class
    public class ApplicationUser : IdentityUser
    {
        public string FormalName { get; set; }
        public string PreferredName { get; set; }
        public string PersonalStatement { get; set; }
    }
}
