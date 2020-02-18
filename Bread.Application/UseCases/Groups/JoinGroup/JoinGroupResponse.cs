using System.Net;

namespace Bread.Application.Groups
{
    public sealed class JoinGroupResponse : BaseGatewayResponse
    {
        public JoinGroupResponse(HttpStatusCode statusCode = HttpStatusCode.NoContent, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
