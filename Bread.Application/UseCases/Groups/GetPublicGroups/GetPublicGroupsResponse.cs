using Bread.Application.Dtos;
using System.Collections.Generic;
using System.Net;

namespace Bread.Application.Groups
{
    public class GetPublicGroupsResponse : BaseGatewayResponse
    {
        public GetPublicGroupsResponse(IEnumerable<GroupDto> groups)
            : base(groups)
        {
        }

        public GetPublicGroupsResponse(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
