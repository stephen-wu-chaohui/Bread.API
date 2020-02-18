using Bread.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bread.Application.Posts
{
    public class CreatePostCommand : IRequest<CreatePostResponse>
    {
        public int AlbumId;
        public PostInfo PostInfo;

        public CreatePostCommand(int albumId, PostInfo postInfo)
        {
            AlbumId = albumId;
            PostInfo = postInfo;
        }
    }
}
