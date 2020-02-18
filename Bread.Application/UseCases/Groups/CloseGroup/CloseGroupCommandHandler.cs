using AutoMapper;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Bread.Application.Repositoies;

namespace Bread.Application.Groups
{
    public class CloseGroupCommandHandler : IRequestHandler<CloseGroupCommand, CloseGroupResponse>
    {
        private readonly IGroupRepository _groupRepository;

        public CloseGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<CloseGroupResponse> Handle(CloseGroupCommand request, CancellationToken cancellationToken)
        {
            await _groupRepository.CloseGroup(request.GroupId);
            return new CloseGroupResponse();
        }
    }
}
