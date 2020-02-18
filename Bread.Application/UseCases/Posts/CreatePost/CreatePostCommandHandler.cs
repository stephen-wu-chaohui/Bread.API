using Bread.Application.Common.Interfaces;
using Bread.Application.Repositoies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bread.Application.Posts
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreatePostCommandHandler(IPostRepository postRepository, ICurrentUserService currentUserService)
        {
            _postRepository = postRepository;
            _currentUserService = currentUserService;
        }

        public async Task<CreatePostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            await _postRepository.CreatePost(request.AlbumId, userId, request.PostInfo);
            return new CreatePostResponse();
        }
    }
}
