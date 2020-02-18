using System;
using System.Collections.Generic;
using System.Text;

namespace Bread.Domain.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
