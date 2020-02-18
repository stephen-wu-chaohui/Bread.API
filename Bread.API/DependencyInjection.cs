using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bread.API.Presenters;
using Hellang.Middleware.ProblemDetails;
using Bread.Application;
using Bread.Domain.Exceptions;
using Bread.API.Configurations;
using Bread.Application.Common.Interfaces;
using Bread.API.Helpers;
using FluentValidation.AspNetCore;
using AutoMapper;
using Bread.Application.Mapping;
using Bread.API.Schemas.Accounts;
using Bread.API.Schemas.Groups;
using Bread.API.Schemas.Albums;
using Bread.API.Schemas.Posts;

namespace Bread.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMvcApiServices(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(
                fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>()
            );
            services.AddAutoMapper(typeof(ApplicationDataMapping), 
                typeof(AccountsDataMappingProfile),
                typeof(GroupsDataMappingProfile),
                typeof(AlbumsDataMappingProfile),
                typeof(PostsDataMappingProfile)
            );

            services.AddSingleton<AccountsControllerPresenter>();
            services.AddSingleton<GroupsControllerPresenter>();
            services.AddSingleton<AlbumsControllerPresenter>();
            services.AddSingleton<PostsControllerPresenter>();

            services.AddProblemDetails(x => {
                x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                x.Map<BreadException>(ex => new BreadExceptionProblemDetails(ex));
                x.Map<Exception>(ex => new OtherExceptionProblemDetails(ex));
            });

            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
