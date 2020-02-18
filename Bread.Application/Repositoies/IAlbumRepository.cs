using Bread.Domain.Dto;
using Bread.Domain.Entities;
using System.Threading.Tasks;

namespace Bread.Application.Repositoies
{
    public interface IAlbumRepository
    {
        Task<Album> CreateAlbum(int hostGroupId, AlbumInfo info);
        Task<Album> UpdateAlbum(int albumId, AlbumInfo info);
        Task<bool> CloseAlbum(int albumId);

    }
}
