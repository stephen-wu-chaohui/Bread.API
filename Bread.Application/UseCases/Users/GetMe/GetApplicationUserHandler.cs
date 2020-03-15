using Bread.Application.Common.Interfaces;
using Bread.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.UseCases.Users
{
    public class GetApplicationUserHandler : IRequestHandler<GetApplicationUserQuery, GetApplicationUserResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICurrentUserService _currentUserService;

        public GetApplicationUserHandler(UserManager<ApplicationUser> userManager, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
        }

        public async Task<GetApplicationUserResponse> Handle(GetApplicationUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(_currentUserService.UserId);
            return new GetApplicationUserResponse(user);
        }
    }
}
