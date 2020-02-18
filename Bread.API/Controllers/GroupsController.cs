using AutoMapper;
using Bread.API.Presenters;
using Bread.API.Schemas.Accounts;
using Bread.API.Schemas.Groups;
using Bread.Application.Common.Interfaces;
using Bread.Application.Groups;
using Bread.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bread.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly GroupsControllerPresenter _presenter;
        private readonly ICurrentUserService _currentUserService;

        public GroupsController(IMediator mediator, IMapper mapper, GroupsControllerPresenter responseMapper, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _presenter = responseMapper;
            _currentUserService = currentUserService;
        }

        // GET: api/Groups/hosted
        [HttpGet("hosted")]
        [ProducesResponseType(typeof(List<JsGroupListItem>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<JsGroupListItem>>> GetHosted()
        {
            var query = new GetHostedGroupsQuery(_currentUserService.UserId);
            var response = await _mediator.Send(query);
            return _presenter.ToDataResult<JsGroupListItem>(response);
        }

        // GET: api/Groups/participated
        [HttpGet("participated")]
        [ProducesResponseType(typeof(List<JsGroupListItem>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<JsGroupListItem>>> GetParticipated()
        {
            var query = new GetParticipatedGroupsQuery(_currentUserService.UserId);
            var response = await _mediator.Send(query);
            return _presenter.ToDataResult<JsGroupListItem>(response);
        }

        // GET: api/Groups/public
        [HttpGet("public")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<JsGroupListItem>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<JsGroupListItem>>> GetPublic()
        {
            var query = new GetPublicGroupsQuery();
            var response = await _mediator.Send(query);
            return _presenter.ToDataResult<JsGroupListItem>(response);
        }

        // GET: api/Groups/{groupId}/members
        [HttpGet("{groupId}/members")]
        [ProducesResponseType(typeof(List<JsUserInfo>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<JsUserInfo>>> GetMembers(int groupId)
        {
            var query = new GetGroupMembersQuery(groupId);
            var response = await _mediator.Send(query);
            return _presenter.ToDataResult<JsUserInfo>(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(JsGroupInfo), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetGroup(int id)
        {
            var query = new GetGroupByIdQuery(id);
            var response = await _mediator.Send(query);
            return _presenter.ToDataResult<JsGroupInfo>(response);
        }

        // POST: api/Groups
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> CreateGroup([FromBody] JsCreateGroup groupInfo)
        {
            var command = new CreateGroupCommand(_currentUserService.UserId, _mapper.Map<GroupInfo>(groupInfo));
            var response = await _mediator.Send(command);
            return _presenter.ToActionResult(response);
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ModifyGroup(int id, [FromBody] JsModifyGroup groupInfo)
        {
            if (id != groupInfo.Id) {
                return Conflict();
            }
            var command = new ModifyGroupCommand(id, _mapper.Map<GroupInfo>(groupInfo));
            var response = await _mediator.Send(command);
            return _presenter.ToActionResult(response);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var command = new CloseGroupCommand(id);
            var response = await _mediator.Send(command);
            return _presenter.ToActionResult(response);
        }
    }
}
