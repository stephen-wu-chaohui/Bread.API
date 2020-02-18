

namespace Bread.API.Schemas.Accounts
{
  public class JsRegisterUserRequest
  {
    public string FormalName { get; set; }
    public string PreferredName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
  }
}
