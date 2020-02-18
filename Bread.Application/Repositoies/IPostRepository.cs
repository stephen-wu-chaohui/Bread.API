using Bread.Domain.Dto;
using Bread.Domain.Entities;
using System.Threading.Tasks;

namespace Bread.Application.Repositoies
{
    public interface IPostRepository
    {
        Task<Post> CreatePost(int hostAlbumId, string issuerId, PostInfo info);
        Task<Post> UpdatePost(int postId, PostInfo info);
        Task<bool> RemovePost(int postId);
    }
}
