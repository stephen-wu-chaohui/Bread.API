using Bread.Domain;
using Bread.Application.Repositoies;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Bread.Domain.Entities;
using System.Text.Json;

namespace Bread.Application.Users
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, UserRegisterResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRegisterCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserRegisterResponse> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser {
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true,
                FormalName = request.FormalName,
                PreferredName = request.PreferredName,
                PersonalStatement = "What a perfect guy"
            };
            var result = await this._userManager.CreateAsync(user, request.Password);
            if (result.Succeeded) {
                return new UserRegisterResponse();
            } else {
                return new UserRegisterResponse(HttpStatusCode.Conflict, JsonSerializer.Serialize(result.Errors));
            }
        }
    }
}
