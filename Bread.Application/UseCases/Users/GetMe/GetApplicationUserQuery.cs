using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bread.Application.UseCases.Users
{
    public class GetApplicationUserQuery : IRequest<GetApplicationUserResponse>
    {
        public GetApplicationUserQuery()
        {
        }
    }
}
