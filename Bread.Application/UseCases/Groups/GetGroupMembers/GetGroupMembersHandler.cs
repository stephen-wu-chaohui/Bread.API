using AutoMapper;
using Bread.Application.Dtos;
using Bread.Application.Repositoies;
using MediatR;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.Groups
{
    public class GetGroupMembersHandler : IRequestHandler<GetGroupMembersQuery, GetGroupMembersResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetGroupMembersHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GetGroupMembersResponse> Handle(GetGroupMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _groupRepository.GetGroupMembers(request.GroupId);
            return new GetGroupMembersResponse(members);
        }
    }
}
