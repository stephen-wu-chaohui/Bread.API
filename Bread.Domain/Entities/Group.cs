using Bread.Domain.Dto;
using Bread.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Domain.Entities
{
    public class Group : Entity<int>
    {
        public string Name { get; set; }

        public string MissionStatement { get; set; }

        public string PrefaceImage { get; set; }

        public string FacebookGroupId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string AdministratorId { get; set; }

        public ICollection<Album> Albums { get; }

        public Group()
        {
            Albums = new List<Album>();
        }

        public void SetAdministrator(string userId)
        {
            AdministratorId = userId;
        }

        public void SetInfo(GroupInfo info)
        {
            Name = info.Name;
            MissionStatement = info.MissionStatement;
            PrefaceImage = info.PrefaceImage;
            FacebookGroupId = info.FacebookGroupId;
        }
    }
}
