using Bread.Domain.Dto;
using MediatR;

namespace Bread.Application.Groups
{
    public class ModifyGroupCommand : IRequest<ModifyGroupResponse>
    {
        public int GroupId { get; }
        public GroupInfo Info { get; }

        public ModifyGroupCommand(int id, GroupInfo groupInfo)
        {
            GroupId = id;
            Info = groupInfo;
        }
    }
}
