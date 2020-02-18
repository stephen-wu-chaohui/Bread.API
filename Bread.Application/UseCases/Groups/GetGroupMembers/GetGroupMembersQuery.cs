using MediatR;

namespace Bread.Application.Groups
{
    public class GetGroupMembersQuery : IRequest<GetGroupMembersResponse>
    {
        public int GroupId { get; }

        public GetGroupMembersQuery(int groupId)
        {
            GroupId = groupId;
        }
    }
}
