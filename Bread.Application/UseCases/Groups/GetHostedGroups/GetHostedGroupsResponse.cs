using Bread.Application.Dtos;
using System.Collections.Generic;
using System.Net;

namespace Bread.Application.Groups
{
    public class GetHostedGroupsResponse : BaseGatewayResponse
    {
        public GetHostedGroupsResponse(IEnumerable<GroupDto> groups)
            : base(groups)
        {
        }

        public GetHostedGroupsResponse(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
