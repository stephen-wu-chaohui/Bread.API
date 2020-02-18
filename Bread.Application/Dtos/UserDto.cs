namespace Bread.Application.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FormalName { get; set; }
        public string PreferredName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
