using AutoMapper;
using Bread.Application.Dtos;
using Bread.Application.Repositoies;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.Groups
{
    public class GetParticipatedGroupsHandler : IRequestHandler<GetParticipatedGroupsQuery, GetParticipatedGroupsResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetParticipatedGroupsHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GetParticipatedGroupsResponse> Handle(GetParticipatedGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.GetParticipatedGroups(request.UserId);
            if (groups != null) {
                return new GetParticipatedGroupsResponse(_mapper.Map<IEnumerable<GroupDto>>(groups));
            } else {
                return new GetParticipatedGroupsResponse(System.Net.HttpStatusCode.NotFound, "User is not found");
            }
        }
    }
}
