using Bread.Application.Dtos;
using System.Net;

namespace Bread.Application.Albums
{
    public sealed class CreateAlbumResponse : BaseGatewayResponse
    {
        public CreateAlbumResponse(int createdAlbumId)
            : base(createdAlbumId, HttpStatusCode.Created)
        {
        }

        public CreateAlbumResponse(HttpStatusCode statusCode, string message = null)
            : base(statusCode, message)
        {
        }
    }
}
