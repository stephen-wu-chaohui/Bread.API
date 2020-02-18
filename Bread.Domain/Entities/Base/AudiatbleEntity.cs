using System;
using System.Collections.Generic;
using System.Text;

namespace Bread.Domain.Entities.Base
{
    public class AudiatbleEntity<T> : Entity<T>
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
