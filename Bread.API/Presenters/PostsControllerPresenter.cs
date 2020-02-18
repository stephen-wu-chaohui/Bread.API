using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bread.API.Helpers;
using Bread.Application;
using Microsoft.AspNetCore.Mvc;

namespace Bread.API.Presenters
{
    public class PostsControllerPresenter : BaseControllerPresenter
    {
        public PostsControllerPresenter(IMapper mapper)
            : base(mapper)
        {
        }
    }
}
