using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bread.Application.Posts
{
    public class ClosePostCommand : IRequest<ClosePostResponse>
    {
        public int PostId { get; }

        public ClosePostCommand(int postId)
        {
            PostId = postId;
        }
    }
}
