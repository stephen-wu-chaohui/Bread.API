using AutoMapper;
using Bread.Application.Dtos;
using Bread.Domain.Dto;
using Bread.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bread.API.Schemas.Groups
{
    public class GroupsDataMappingProfile : Profile
    {
        public GroupsDataMappingProfile()
        {
            CreateMap<JsCreateGroup, GroupInfo>();
            CreateMap<JsModifyGroup, GroupInfo>();
            CreateMap<GroupInfo, JsGroupInfo>();
            CreateMap<GroupInfo, JsGroupListItem>();
            CreateMap<GroupDto, JsGroupListItem>();
            CreateMap<GroupDto, JsGroupInfo>();
            CreateMap<Group, JsGroupListItem>();
            CreateMap<Group, JsGroupInfo>();
        }
    }
}
