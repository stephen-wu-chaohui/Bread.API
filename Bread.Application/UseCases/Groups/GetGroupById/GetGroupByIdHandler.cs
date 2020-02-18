using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bread.Application.Dtos;
using Bread.Application.Repositoies;
using MediatR;

namespace Bread.Application.Groups
{
    public class GetGroupByIdHandler : IRequestHandler<GetGroupByIdQuery, GetGroupByIdResponse>
    {
        private readonly IGroupRepository _groupRepository;

        public GetGroupByIdHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
        }

        public async Task<GetGroupByIdResponse> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetGroupById(request.GroupId);
            if (group != null) {
                return new GetGroupByIdResponse(group);
            } else {
                return new GetGroupByIdResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
