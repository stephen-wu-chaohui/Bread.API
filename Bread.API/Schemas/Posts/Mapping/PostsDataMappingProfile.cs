using AutoMapper;
using Bread.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bread.API.Schemas.Posts
{
    public class PostsDataMappingProfile : Profile
    {
        public PostsDataMappingProfile()
        {
            CreateMap<JsCreatePost, PostInfo>();
            CreateMap<JsModifyPost, PostInfo>();
            CreateMap<PostInfo, JsPostInfo>();
            CreateMap<PostInfo, JsPostListItem>();
        }
    }
}
