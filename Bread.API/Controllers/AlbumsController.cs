using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Bread.API.Schemas.Albums;
using Bread.API.Presenters;
using Bread.Application.Albums;
using Bread.Application.Common.Interfaces;
using Bread.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bread.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly AlbumsControllerPresenter _presenter;

        public AlbumsController(IMediator mediator, IMapper mapper, AlbumsControllerPresenter responseMapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _presenter = responseMapper;
        }

        // POST: api/Albums
        [HttpPost("{groupId}/create")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> CreateAlbum(int groupId, [FromBody] JsCreateAlbum albumInfo)
        {
            var command = new CreateAlbumCommand(groupId, _mapper.Map<AlbumInfo>(albumInfo));
            var response = await _mediator.Send(command);
            return _presenter.ToActionResult(response);
        }

        // PUT: api/Albums/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ModifyAlbum(int id, [FromBody] JsModifyAlbum albumInfo)
        {
            var command = new ModifyAlbumCommand(id, _mapper.Map<AlbumInfo>(albumInfo));
            var response = await _mediator.Send(command);
            return _presenter.ToActionResult(response);
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var command = new CloseAlbumCommand(id);
            var response = await _mediator.Send(command);
            return _presenter.ToActionResult(response);
        }
    }
}