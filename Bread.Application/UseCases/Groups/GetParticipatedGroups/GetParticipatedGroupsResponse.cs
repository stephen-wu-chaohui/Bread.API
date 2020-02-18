using Bread.Application.Dtos;
using System.Collections.Generic;
using System.Net;

namespace Bread.Application.Groups
{
    public class GetParticipatedGroupsResponse : BaseGatewayResponse
    {
        public GetParticipatedGroupsResponse(IEnumerable<GroupDto> groups)
            : base(groups)
        {
        }

        public GetParticipatedGroupsResponse(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
