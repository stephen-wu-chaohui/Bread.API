using System.Net;

namespace Bread.Application.Users
{
    public class UserLogoutResponse : BaseGatewayResponse
    {
        public UserLogoutResponse()
        {
        }

        public UserLogoutResponse(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
