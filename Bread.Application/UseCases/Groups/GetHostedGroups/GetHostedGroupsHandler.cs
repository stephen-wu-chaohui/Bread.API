using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bread.Application.Dtos;
using Bread.Application.Repositoies;
using MediatR;

namespace Bread.Application.Groups
{
    public class GetHostedGroupsHandler : IRequestHandler<GetHostedGroupsQuery, GetHostedGroupsResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetHostedGroupsHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GetHostedGroupsResponse> Handle(GetHostedGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.GetHostedGroups(request.UserId);
            if (groups != null) {
                return new GetHostedGroupsResponse(_mapper.Map<IEnumerable<GroupDto>>(groups));
            } else {
                return new GetHostedGroupsResponse(HttpStatusCode.NotFound, "User is not found");
            }
        }
    }
}
