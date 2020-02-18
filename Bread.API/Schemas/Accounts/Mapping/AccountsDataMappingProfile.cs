using AutoMapper;
using Bread.API.Schemas.Accounts;
using Bread.Application.Users;
using Bread.Domain.Entities;

namespace Bread.API.Schemas.Accounts
{
    public class AccountsDataMappingProfile : Profile
    {
        public AccountsDataMappingProfile()
        {
            CreateMap<JsLoginRequest, UserLoginCommand>();
            CreateMap<JsRegisterUserRequest, UserRegisterCommand>();

            CreateMap<ApplicationUser, JsUserInfo>();
        }
    }
}
