using Bread.Application.Dtos;
using Bread.Domain.Entities;
using System.Collections.Generic;
using System.Net;

namespace Bread.Application.Groups
{
    public class GetGroupMembersResponse : BaseGatewayResponse
    {
        public GetGroupMembersResponse(IEnumerable<ApplicationUser> members)
            : base(members)
        {
        }

        public GetGroupMembersResponse(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
