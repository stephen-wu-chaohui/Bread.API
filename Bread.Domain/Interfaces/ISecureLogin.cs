using Bread.Domain.Dto;
using Bread.Domain.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bread.Domain.Interfaces
{
    public interface ISecureLogin
    {
        Task<LoginInfo> SecureLogin(ApplicationUser user);
    }
}
