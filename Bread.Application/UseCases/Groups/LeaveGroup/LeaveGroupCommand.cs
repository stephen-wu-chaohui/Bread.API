using MediatR;

namespace Bread.Application.Groups
{
    public class LeaveGroupCommand : IRequest<LeaveGroupResponse>
    {
        public string UserId { get; }
        public int GroupId { get; }

        public LeaveGroupCommand(string userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}
