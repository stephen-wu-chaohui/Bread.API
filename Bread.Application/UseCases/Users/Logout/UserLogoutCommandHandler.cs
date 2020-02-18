using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Bread.Application.Repositoies;
using Microsoft.AspNetCore.Identity;
using Bread.Domain.Entities;

namespace Bread.Application.Users
{
    public class UserLogoutCommandHandler : IRequestHandler<UserLogoutCommand, UserLogoutResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserLogoutCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserLogoutResponse> Handle(UserLogoutCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId == null) {
                return new UserLogoutResponse(HttpStatusCode.Unauthorized, "No online user");
            } else {
                return new UserLogoutResponse();
            }
        }
    }
}
