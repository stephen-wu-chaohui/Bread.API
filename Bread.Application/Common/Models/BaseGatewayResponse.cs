using System.Net;
using System.Text.Json.Serialization;

namespace Bread.Application
{
    public class BaseGatewayResponse
    {
        public HttpStatusCode StatusCode { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public string ContentType { get; protected set; }
        public object MessageBody { get; }

        public BaseGatewayResponse(HttpStatusCode statusCode = HttpStatusCode.NoContent, string message = null)
        {
            StatusCode = statusCode;
            ContentType = "application/json";
            ErrorMessage = message;
        }

        public BaseGatewayResponse(object body, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            MessageBody = body;
            StatusCode = statusCode;
            ContentType = "application/json";
        }
    }
}

