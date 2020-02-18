using Bread.Domain.Dto;
using Bread.Domain.Entities;
using MediatR;

namespace Bread.Application.Albums
{
    public class CreateAlbumCommand : IRequest<CreateAlbumResponse>
    {
        public int GroupId { get; }
        public AlbumInfo AlbumInfo { get; }

        public CreateAlbumCommand(int groupId, AlbumInfo albumInfo)
        {
            GroupId = groupId;
            AlbumInfo = albumInfo;
        }
    }
}