using Bread.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bread.Application.Posts
{
    public class UpdatePostCommand : IRequest<UpdatePostResponse>
    {
        public int PostId { get; }
        public PostInfo PostInfo { get; }

        public UpdatePostCommand(int id, PostInfo postInfo)
        {
            PostId = id;
            PostInfo = postInfo;
        }
    }
}
