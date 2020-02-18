using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.Services
{
    public interface IUserValidationService
    {
        Task<bool> IsEmailUnique(string emailAddress, CancellationToken cancellationToken = default);
    }
}
