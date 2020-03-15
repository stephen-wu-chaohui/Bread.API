using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bread.Domain.Entities;

namespace Bread.Application.Repositoies
{
    public interface IVideoRepository
    {
        Task<IEnumerable<PlayList>> LoadChannelAsync(string channelId, bool refresh);
        Task<IEnumerable<PlayItem>> LoadPlayItemsAsync(string playlistId);
    }
}
