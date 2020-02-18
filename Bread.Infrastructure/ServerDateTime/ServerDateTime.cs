using Bread.Domain;
using Bread.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bread.Infrastructure
{
    public class ServerDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
