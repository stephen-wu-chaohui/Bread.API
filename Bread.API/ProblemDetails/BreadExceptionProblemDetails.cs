using System;
using Bread.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Bread.API.Presenters
{
    public class BreadExceptionProblemDetails : ProblemDetails
    {
        public BreadExceptionProblemDetails(BreadException exception)
        {
            this.Title = exception.Message;
            this.Status = Map(exception.ExceptionCode);
            this.Type = "https://bread.com/bread-error";
        }

        private int Map(BreadExceptionCode code)
        {
            switch(code) {
                case BreadExceptionCode.UserIsUnknown:
                case BreadExceptionCode.AlbumIdIsUnknown:
                case BreadExceptionCode.GroupIdIsUnknown:
                case BreadExceptionCode.PostIdIsUnknown:
                    return StatusCodes.Status404NotFound;
                case BreadExceptionCode.GroupIsClosed:
                case BreadExceptionCode.AlbumIsClosed:
                case BreadExceptionCode.PostIdIsClosed:
                    return StatusCodes.Status406NotAcceptable;
                case BreadExceptionCode.UserIsDenied:
                    return StatusCodes.Status403Forbidden;
                default:
                    return StatusCodes.Status400BadRequest;
            }
        }
    }
}
