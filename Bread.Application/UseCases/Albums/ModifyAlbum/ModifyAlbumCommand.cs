using Bread.Domain.Dto;
using MediatR;

namespace Bread.Application.Albums
{
    public class ModifyAlbumCommand : IRequest<ModifyAlbumResponse>
    {
        public int AlbumId { get; }
        public AlbumInfo AlbumInfo { get; }

        public ModifyAlbumCommand(int id, AlbumInfo albumInfo)
        {
            this.AlbumId = id;
            this.AlbumInfo = albumInfo;
        }
    }
}