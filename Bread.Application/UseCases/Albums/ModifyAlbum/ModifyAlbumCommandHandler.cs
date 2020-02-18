using Bread.Application.Repositoies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.Albums
{
    public class ModifyAlbumCommandHandler : IRequestHandler<ModifyAlbumCommand, ModifyAlbumResponse>
    {
        private readonly IAlbumRepository _albumRepository;

        public ModifyAlbumCommandHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }


        public async Task<ModifyAlbumResponse> Handle(ModifyAlbumCommand request, CancellationToken cancellationToken)
        {
            await _albumRepository.UpdateAlbum(request.AlbumId, request.AlbumInfo);
            return new ModifyAlbumResponse();
        }
    }
}
