using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Bread.API.Presenters;
using Microsoft.AspNetCore.Authorization;
using Bread.Application.Users;
using Bread.API.Schemas.Accounts;
using Bread.Domain.Entities;
using System.Net;
using Bread.Application.UseCases.Users;

namespace Bread.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly AccountsControllerPresenter _representer;

        public AccountsController(IMediator mediator, IMapper mapper, AccountsControllerPresenter responseMapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _representer = responseMapper;
        }

        // POST api/accounts
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] JsRegisterUserRequest request)
        {
            var result = await _mediator.Send(_mapper.Map<UserRegisterCommand>(request));
            return _representer.ToActionResult(result);
        }

        // POST api/accounts/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] JsLoginRequest request)
        {
            var result = await _mediator.Send(_mapper.Map<UserLoginCommand>(request));
            return _representer.ToActionResult(result);
        }

        // GET api/accounts/me
        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(typeof(JsUserInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMe()
        {
            var query = new GetApplicationUserQuery();
            var response = await _mediator.Send(query);
            return _representer.ToDataResult<JsUserInfo>(response);
        }

        // POST api/accounts/logout
        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            var result = await _mediator.Send(new UserLogoutCommand(this.User?.Identity?.Name));
            return _representer.ToActionResult(result);
        }

    }
}
