using MediatR;

namespace Bread.Application.Albums
{
    public class CloseAlbumCommand : IRequest<CloseAlbumResponse>
    {
        public int AlbumId { get; set; }

        public CloseAlbumCommand(int id)
        {
            AlbumId = id;
        }
    }
}