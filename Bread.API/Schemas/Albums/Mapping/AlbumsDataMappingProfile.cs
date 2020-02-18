using AutoMapper;
using Bread.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bread.API.Schemas.Albums
{
    public class AlbumsDataMappingProfile : Profile
    {
        public AlbumsDataMappingProfile()
        {
            CreateMap<JsCreateAlbum, AlbumInfo>();
            CreateMap<JsModifyAlbum, AlbumInfo>();
            CreateMap<AlbumInfo, JsAlbumInfo>();
            CreateMap<AlbumInfo, JsAlbumListItem>();
        }
    }
}
