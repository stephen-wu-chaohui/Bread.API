using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Bread.Domain.Entities;
using Bread.Domain.Interfaces;

namespace Bread.Application.Users
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoginResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ISecureLogin _secureLogin;

        public UserLoginCommandHandler(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ISecureLogin secureLogin)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _secureLogin = secureLogin;
        }

        public async Task<UserLoginResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.UserName) && !string.IsNullOrEmpty(request.Password)) {
                var user = await _userManager.FindByNameAsync(request.UserName) ?? await _userManager.FindByEmailAsync(request.UserName);
                if (user != null) {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
                    if (result.Succeeded) {
                        return new UserLoginResponse(await _secureLogin.SecureLogin(user));
                    }
                }
            }
            return new UserLoginResponse(HttpStatusCode.Unauthorized, "Invalid User name or password");
        }
    }
}
