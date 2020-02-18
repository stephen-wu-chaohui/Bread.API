using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bread.Application.Repositoies;
using MediatR;

namespace Bread.Application.Groups
{
    public class LeaveGroupCommandHandler : IRequestHandler<LeaveGroupCommand, LeaveGroupResponse>
    {
        private readonly IGroupRepository _groupRepository;

        public LeaveGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<LeaveGroupResponse> Handle(LeaveGroupCommand request, CancellationToken cancellationToken)
        {
            await _groupRepository.LeaveGroup(request.UserId, request.GroupId);
            return new LeaveGroupResponse();
        }
    }
}
