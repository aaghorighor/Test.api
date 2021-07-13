using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Test.Logger.Services.Middleware
{  
    public class HttpExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpExceptionHandler> _logger;

        public HttpExceptionHandler(RequestDelegate next, ILogger<HttpExceptionHandler> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex);
            }
        }

        private Task HandleAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

           _logger.LogError($"Error: {ex}");            

            return context.Response.WriteAsync($"Internal Server Error");
        }
    }
}
