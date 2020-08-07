using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPublico.Core.Helpers.GlobalErrorHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        // private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next)
        {
            // _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // return context.Response.WriteAsync(new ErrorDetails()
            // {
            //     code = context.Response.StatusCode,
            //     message = $"Internal Server Error: {exception.Message}."
            // }.ToString());
            var or = new CustomObjectResult()
            {
                success = false,
                data = new ErrorDetails()
                {
                    code = context.Response.StatusCode,
                    message = $"Internal Server Error: {exception.Message}."
                }
            };

            return context.Response.WriteAsync(or.ToString());
        }
    }
}