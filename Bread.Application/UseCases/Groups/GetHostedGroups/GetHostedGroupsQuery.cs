using MediatR;

namespace Bread.Application.Groups
{
    public class GetHostedGroupsQuery : IRequest<GetHostedGroupsResponse>
    {
        public string UserId { get; internal set; }

        public GetHostedGroupsQuery(string userId)
        {
            UserId = userId;
        }
    }
}
