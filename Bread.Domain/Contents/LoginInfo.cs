namespace Bread.Domain.Dto
{
    public sealed class LoginInfo
    {
        public string UserId { get; }
        public string AuthToken { get; }
        public int ExpiresIn { get; }

        public LoginInfo(string userId, string authToken, int expiresIn)
        {
            UserId = userId;
            AuthToken = authToken;
            ExpiresIn = expiresIn;
        }
    }
}
