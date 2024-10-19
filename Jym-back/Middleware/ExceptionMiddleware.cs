using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Jym_back.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleGlobalExceptionAsync(context, StatusCodes.Status500InternalServerError, ex);
            }
        }

        private Task HandleGlobalExceptionAsync(HttpContext context, int statusCode, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.ToString(),
            }.ToString());
        }

        public class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }

            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}
