using Bread.Domain.Dto;
using System.Net;

namespace Bread.Application.Users
{
    public sealed class UserLoginResponse : BaseGatewayResponse
    {
        public UserLoginResponse(LoginInfo token)
            : base(token)
        {
        }

        public UserLoginResponse(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
