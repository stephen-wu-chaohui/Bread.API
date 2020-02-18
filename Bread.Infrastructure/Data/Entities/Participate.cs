using Bread.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Infrastructure.Data.Entities
{
    public class Participate : Entity<int>
    {
        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
    }
}
