using Bread.Application.Repositoies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.Posts
{
    public class ClosePostCommandHandler : IRequestHandler<ClosePostCommand, ClosePostResponse>
    {
        private readonly IPostRepository _postRepository;

        public ClosePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ClosePostResponse> Handle(ClosePostCommand request, CancellationToken cancellationToken)
        {
            await _postRepository.RemovePost(request.PostId);
            return new ClosePostResponse();
        }
    }
}
