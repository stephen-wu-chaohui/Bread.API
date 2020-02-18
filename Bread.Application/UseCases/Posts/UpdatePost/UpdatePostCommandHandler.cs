using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.Posts
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostResponse>
    {
        public Task<UpdatePostResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
