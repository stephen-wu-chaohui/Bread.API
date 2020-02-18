using AutoMapper;
using Bread.Application.Dtos;
using Bread.Application.Repositoies;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.Groups
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, CreateGroupResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public CreateGroupCommandHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<CreateGroupResponse> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.CreateGroup(request.UserId, request.Info);
            return new CreateGroupResponse(group.Id);
        }
    }
}
