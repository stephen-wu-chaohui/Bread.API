using MediatR;

namespace Bread.Application.Groups
{
    public class GetGroupByIdQuery : IRequest<GetGroupByIdResponse>
    {
        public int GroupId { get; }

        public GetGroupByIdQuery(int groupId)
        {
            GroupId = groupId;
        }
    }
}
