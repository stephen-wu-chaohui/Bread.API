using Bread.Domain.Dto;
using MediatR;

namespace Bread.Application.Groups
{
    public class CreateGroupCommand : IRequest<CreateGroupResponse>
    {
        public string UserId { get; }
        public GroupInfo Info { get; }

        public CreateGroupCommand(string userId, GroupInfo groupInfo)
        {
            UserId = userId;
            Info = groupInfo;
        }
    }
}
