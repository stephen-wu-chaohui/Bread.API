using Bread.Domain.Dto;
using Bread.Domain.Entities;
using Bread.Domain.Exceptions;
using Bread.Application.Repositoies;
using Bread.Infrastructure.Data.DbContexts;
using System.Threading.Tasks;

namespace Bread.Infrastructure.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> CreatePost(int hostAlbumId, string issuerId, PostInfo info)
        {
            Album host = await _dbContext.Albums.FindAsync(hostAlbumId);
            if (host == null) {
                throw new BreadException(BreadExceptionCode.AlbumIdIsUnknown);
            }
            ApplicationUser issuer = await _dbContext.Users.FindAsync(issuerId);
            if (issuer == null) {
                throw new BreadException(BreadExceptionCode.UserIsUnknown);
            }

            var post = new Post();
            post.SetIssuer(issuer);
            post.SetInfo(info);

            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdatePost(int postId, PostInfo info)
        {
            var post = _dbContext.Posts.Find(postId);
            if (post == null) {
                throw new BreadException(BreadExceptionCode.PostIdIsUnknown, $"Invalid Post Id: {postId}");
            }

            post.SetInfo(info);

            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<bool> RemovePost(int postId)
        {
            var post = _dbContext.Posts.Find(postId);

            if (post == null) {
                throw new BreadException(BreadExceptionCode.PostIdIsUnknown, $"Invalid Post Id: {postId}");
            }

            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
