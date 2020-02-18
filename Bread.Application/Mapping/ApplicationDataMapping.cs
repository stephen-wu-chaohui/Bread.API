using AutoMapper;
using Bread.Application.Dtos;
using Bread.Domain.Entities;

namespace Bread.Application.Mapping
{
    public class ApplicationDataMapping : Profile
    {
        public ApplicationDataMapping()
        {
            CreateMap<Group, GroupDto>();
        }
    }
}
