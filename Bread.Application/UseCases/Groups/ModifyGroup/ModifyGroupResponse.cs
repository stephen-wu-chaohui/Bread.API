using Bread.Application.Dtos;
using System.Net;

namespace Bread.Application.Groups
{
    public sealed class ModifyGroupResponse : BaseGatewayResponse
    {
        public ModifyGroupResponse(HttpStatusCode statusCode = HttpStatusCode.NoContent, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
