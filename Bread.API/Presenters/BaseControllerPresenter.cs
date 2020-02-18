using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Bread.API.Helpers;
using Bread.Application;

namespace Bread.API.Presenters
{
    public class BaseControllerPresenter
    {
        private readonly IMapper _mapper;

        public BaseControllerPresenter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ActionResult ToActionResult(BaseGatewayResponse baseGatewayResponse)
        {
            return new ContentResult() {
                StatusCode = (int)baseGatewayResponse.StatusCode,
                ContentType = baseGatewayResponse.ContentType,
                Content = baseGatewayResponse.MessageBody != null
                    ? JsonSerializer.SerializeObject(baseGatewayResponse.MessageBody)
                    : baseGatewayResponse.ErrorMessage
            };
        }

        public ActionResult ToDataResult<TDest>(BaseGatewayResponse response)
        {
            return new ContentResult() {
                StatusCode = (int)response.StatusCode,
                ContentType = response.ContentType,
                Content = response.MessageBody == null
                    ? response.ErrorMessage
                    : response.MessageBody is IEnumerable<object> items
                    ? JsonSerializer.SerializeObject(items.Select(_mapper.Map<TDest>))
                    : JsonSerializer.SerializeObject(_mapper.Map<TDest>(response.MessageBody))
            };
        }
    }
}
