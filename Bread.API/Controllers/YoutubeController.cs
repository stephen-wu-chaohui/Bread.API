using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bread.Application.Repositoies;
using Bread.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bread.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class PlaylistsController : Controller
    {
        private readonly IVideoRepository videoRepository;

        public PlaylistsController(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }


        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<PlayList>> LoadChannelAsync(string channelId, bool refresh = false)
        {
            return await videoRepository.LoadChannelAsync(channelId, refresh);
        }
    }

    [Route("api/[controller]")]
    public class PlayitemsController : Controller
    {
        private readonly IVideoRepository videoRepository;

        public PlayitemsController(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<PlayItem>> LoadPlayItemsAsync(string playlistId)
        {
            return await videoRepository.LoadPlayItemsAsync(playlistId);
        }
    }
}
