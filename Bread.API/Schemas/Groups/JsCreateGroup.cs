using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bread.API.Schemas.Groups
{
    public class JsCreateGroup
    {
        public string Name { get; set; }
        public string MissionStatement { get; set; }
        public string PrefaceImage { get; set; }
        public string FacebookGroupId { get; set; }
    }
}
