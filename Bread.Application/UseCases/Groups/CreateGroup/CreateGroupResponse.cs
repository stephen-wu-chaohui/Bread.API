using Bread.Application.Dtos;
using System.Net;

namespace Bread.Application.Groups
{
    public sealed class CreateGroupResponse : BaseGatewayResponse
    {
        public CreateGroupResponse(int createdGroupId)
            : base(createdGroupId, HttpStatusCode.Created)
        {
        }

        public CreateGroupResponse(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
