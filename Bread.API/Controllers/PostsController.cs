using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using Bread.API.Presenters;
using Bread.API.Schemas.Posts;
using Bread.Application.Common.Interfaces;
using Bread.Application.Posts;
using Bread.Domain.Dto;

namespace Bread.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly PostsControllerPresenter _presenter;

        public PostsController(IMediator mediator, IMapper mapper, PostsControllerPresenter responseMapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _presenter = responseMapper;
        }

        // POST: api/Posts
        [HttpPost("{albumId}/create")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> CreatePost(int albumId, [FromBody] JsCreatePost albumInfo)
        {
            var command = new CreatePostCommand(albumId, _mapper.Map<PostInfo>(albumInfo));
            var response = await _mediator.Send(command);
            return _presenter.ToActionResult(response);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ModifyPost(int id, [FromBody] JsModifyPost albumInfo)
        {
            var command = new UpdatePostCommand(id, _mapper.Map<PostInfo>(albumInfo));
            var response = await _mediator.Send(command);
            return _presenter.ToActionResult(response);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeletePost(int id)
        {
            var command = new ClosePostCommand(id);
            var response = await _mediator.Send(command);
            return _presenter.ToActionResult(response);
        }
    }
}