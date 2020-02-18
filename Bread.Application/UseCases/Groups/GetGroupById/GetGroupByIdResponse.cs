using Bread.Domain.Entities;
using System.Net;

namespace Bread.Application.Groups
{
    public class GetGroupByIdResponse : BaseGatewayResponse
    {
        public GetGroupByIdResponse(Group group)
            : base(group)
        {
        }

        public GetGroupByIdResponse(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
