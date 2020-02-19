using Bread.Application.Services;
using Bread.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Infrastructure.Services
{
    public class UserValidationService : IUserValidationService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserValidationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> IsEmailUnique(string emailAddress, CancellationToken cancellationToken = default)
        {
            return await _userManager.FindByEmailAsync(emailAddress) == null;
        }
    }
}
