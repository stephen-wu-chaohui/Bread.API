using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Bread.Application.Repositoies;

namespace Bread.Application.Groups
{
    public class ModifyGroupCommandHandler : IRequestHandler<ModifyGroupCommand, ModifyGroupResponse>
    {
        private readonly IGroupRepository _groupRepository;

        public ModifyGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<ModifyGroupResponse> Handle(ModifyGroupCommand request, CancellationToken cancellationToken)
        {
            await _groupRepository.UpdateGroupInfo(request.GroupId, request.Info);
            return new ModifyGroupResponse();
        }
    }
}
