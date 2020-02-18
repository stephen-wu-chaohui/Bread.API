using AutoMapper;
using Bread.Application.Dtos;
using Bread.Application.Repositoies;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.Groups
{
    public class GetPublicGroupsHandler : IRequestHandler<GetPublicGroupsQuery, GetPublicGroupsResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetPublicGroupsHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GetPublicGroupsResponse> Handle(GetPublicGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.GetPublicGroups();
            if (groups != null) {
                return new GetPublicGroupsResponse(_mapper.Map<IEnumerable<GroupDto>>(groups));
            } else {
                return new GetPublicGroupsResponse(System.Net.HttpStatusCode.NotFound, "User is not found");
            }
        }
    }
}
