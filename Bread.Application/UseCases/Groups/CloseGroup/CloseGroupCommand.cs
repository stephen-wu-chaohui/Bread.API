using MediatR;

namespace Bread.Application.Groups
{
    public class CloseGroupCommand : IRequest<CloseGroupResponse>
    {
        public int GroupId { get; }

        public CloseGroupCommand(int idGroup)
        {
            this.GroupId = idGroup;
        }
    }
}
