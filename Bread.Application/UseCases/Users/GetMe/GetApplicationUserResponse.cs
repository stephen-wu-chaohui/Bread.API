using Bread.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Bread.Application.UseCases.Users
{
    public class GetApplicationUserResponse : BaseGatewayResponse
    {
        public GetApplicationUserResponse(ApplicationUser applicationUser)
            : base(applicationUser)
        {
        }

        public GetApplicationUserResponse(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
