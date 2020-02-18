using MediatR;

namespace Bread.Application.Users
{
    public class UserRegisterCommand : IRequest<UserRegisterResponse>
    {
        public string FormalName { get; internal set; }
        public string PreferredName { get; internal set; }
        public string UserName { get; internal set; }
        public string Password { get; internal set; }
        public string Email { get; internal set; }
    }

}
