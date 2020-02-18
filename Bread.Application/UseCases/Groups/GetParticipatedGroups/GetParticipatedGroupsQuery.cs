using MediatR;

namespace Bread.Application.Groups
{
    public class GetParticipatedGroupsQuery : IRequest<GetParticipatedGroupsResponse>
    {
        public string UserId { get; }

        public GetParticipatedGroupsQuery(string userId)
        {
            UserId = userId;
        }
    }
}
