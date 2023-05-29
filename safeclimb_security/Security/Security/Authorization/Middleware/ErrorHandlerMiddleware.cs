using System.Net;
using System.Text.Json;
using safeclimb_security.Security.Security.Exceptions;

namespace safeclimb_security.Security.Security.Authorization.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int) HttpStatusCode.BadRequest;

                switch (error)
                {
                    case AppException e:
                        response.StatusCode = (int) HttpStatusCode.BadRequest;
                        break; 
                    case KeyNotFoundException e:
                        response.StatusCode = (int) HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new {message = error?.Message});
                await response.WriteAsync(result);
            }
        }
    }
}