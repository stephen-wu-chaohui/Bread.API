using System.Net;

namespace Bread.Application.Groups
{
    public sealed class LeaveGroupResponse : BaseGatewayResponse
    {
        public LeaveGroupResponse(HttpStatusCode statusCode = HttpStatusCode.NoContent, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
