using MediatR;

namespace Bread.Application.Groups
{
    public class JoinGroupCommand : IRequest<JoinGroupResponse>
    {
        public string UserId { get; }
        public int GroupId { get; }

        public JoinGroupCommand(string userId, int groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }
}
