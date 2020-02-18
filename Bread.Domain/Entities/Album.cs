using Bread.Domain.Dto;
using Bread.Domain.Entities.Base;
using System.Collections.Generic;

namespace Bread.Domain.Entities
{
    public class Album : Entity<int>
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; } = new List<Post>();

        internal void SetInfo(AlbumInfo info)
        {
            Name = info.Name;
            Description = info.Description;
        }
    }
}
