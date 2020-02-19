using System.Threading.Tasks;
using Bread.Domain.Dto;
using Bread.Domain.Entities;
using Bread.Domain.Exceptions;
using Bread.Application.Repositoies;
using Bread.Infrastructure.Data.DbContexts;

namespace Bread.Infrastructure.Data.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AlbumRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Album> CreateAlbum(int hostGroupId, AlbumInfo info)
        {
            Group host = await _dbContext.Groups.FindAsync(hostGroupId);
            if (host == null) {
                throw new BreadException(BreadExceptionCode.GroupIdIsUnknown);
            }

            var album = new Album();
            album.SetInfo(info);
            album.GroupId = hostGroupId;

            await _dbContext.Albums.AddAsync(album);
            await _dbContext.SaveChangesAsync();
            return album;
        }

        public async Task<Album> UpdateAlbum(int albumId, AlbumInfo info)
        {
            var album = _dbContext.Albums.Find(albumId);
            if (album == null) {
                throw new BreadException(BreadExceptionCode.AlbumIdIsUnknown, $"{albumId} is unknown");
            }

            album.SetInfo(info);

            await _dbContext.SaveChangesAsync();
            return album;
        }

        public async Task<bool> CloseAlbum(int albumId)
        {
            var album = _dbContext.Albums.Find(albumId);
            if (album == null) {
                throw new BreadException(BreadExceptionCode.AlbumIdIsUnknown, $"{albumId} is unknown");
            }

            _dbContext.Albums.Remove(album);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
