using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Bread.API.Presenters
{
    public class OtherExceptionProblemDetails : ProblemDetails
    {
        public OtherExceptionProblemDetails(Exception exception)
        {
            this.Title = exception.Message;
            this.Status = StatusCodes.Status500InternalServerError;
            this.Detail = exception.StackTrace;
            this.Type = "https://somedomain/unknown-error";
        }
    }
}
