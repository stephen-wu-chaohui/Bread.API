using MediatR;

namespace Bread.Application.Users
{
    public class UserLoginCommand : IRequest<UserLoginResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
