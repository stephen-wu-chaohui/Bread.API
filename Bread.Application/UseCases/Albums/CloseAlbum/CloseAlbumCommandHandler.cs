using AutoMapper;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Bread.Application.Repositoies;

namespace Bread.Application.Albums
{
    public class CloseAlbumCommandHandler : IRequestHandler<CloseAlbumCommand, CloseAlbumResponse>
    {
        private readonly IAlbumRepository _groupRepository;

        public CloseAlbumCommandHandler(IAlbumRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<CloseAlbumResponse> Handle(CloseAlbumCommand request, CancellationToken cancellationToken)
        {
            await _groupRepository.CloseAlbum(request.AlbumId);
            return new CloseAlbumResponse();
        }
    }
}
