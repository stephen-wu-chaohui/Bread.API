using System.Net;

namespace Bread.Application.Groups
{
    public class CloseGroupResponse : BaseGatewayResponse
    {
        public CloseGroupResponse(HttpStatusCode statusCode = HttpStatusCode.NoContent, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
