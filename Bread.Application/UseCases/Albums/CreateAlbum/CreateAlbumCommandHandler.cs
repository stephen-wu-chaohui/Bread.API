using AutoMapper;
using Bread.Application.Repositoies;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.Albums
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, CreateAlbumResponse>
    {
        private readonly IAlbumRepository _albumRepository;

        public CreateAlbumCommandHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<CreateAlbumResponse> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = await _albumRepository.CreateAlbum(request.GroupId, request.AlbumInfo);
            return new CreateAlbumResponse(album.Id);
        }
    }
}
