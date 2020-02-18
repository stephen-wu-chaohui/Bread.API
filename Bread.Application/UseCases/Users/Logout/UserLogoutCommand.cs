using MediatR;

namespace Bread.Application.Users
{
    public class UserLogoutCommand : IRequest<UserLogoutResponse>
    {
        public string UserId { get; }

        public UserLogoutCommand(string userId)
        {
            UserId = userId;
        }
    }
}
