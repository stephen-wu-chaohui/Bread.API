using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bread.Application.Repositoies;
using MediatR;

namespace Bread.Application.Groups
{
    public class JoinGroupCommandHandler : IRequestHandler<JoinGroupCommand, JoinGroupResponse>
    {
        private readonly IGroupRepository _groupRepository;

        public JoinGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<JoinGroupResponse> Handle(JoinGroupCommand request, CancellationToken cancellationToken)
        {
            await _groupRepository.JoinGroup(request.UserId, request.GroupId);
            return new JoinGroupResponse();
        }
    }
}
