using Bread.Domain.Dto;
using Bread.Domain.Entities.Base;

namespace Bread.Domain.Entities
{
    public class Post : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ApplicationUser Issuer { get; set; }

        internal void SetIssuer(ApplicationUser issuer)
        {
            Issuer = issuer;
        }

        internal void SetInfo(PostInfo info)
        {
            Title = info.Title;
            Description = info.Description;
        }
    }
}
