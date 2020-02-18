using System.Collections.Generic;
using System.Net;

namespace Bread.Application.Users
{
    public sealed class UserRegisterResponse : BaseGatewayResponse
    {
        public UserRegisterResponse(HttpStatusCode statusCode = HttpStatusCode.Created, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
