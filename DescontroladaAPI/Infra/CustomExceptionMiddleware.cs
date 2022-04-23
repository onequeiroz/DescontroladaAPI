using DescontroladaAPI.Models;
using System.Net;
using System.Text.Json;

namespace DescontroladaAPI.Infra
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
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
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var resultModel = new ReturnObjectModel() { ErrorResponse = new ErrorResponseModel[1] };
                ReturnObject.BuildErrorResponseObject(resultModel, error?.Message, error?.InnerException?.Message);

                var result = JsonSerializer.Serialize(resultModel);
                await context.Response.WriteAsync(result);
            }
        }
    }
}
