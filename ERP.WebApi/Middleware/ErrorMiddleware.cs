using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using ERP.WebApi.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ERP.WebApi.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ErrorMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                var res = _env.IsDevelopment()
                    ? new ApiException((int) HttpStatusCode.InternalServerError, e.Message, e.StackTrace)
                    : new ApiException((int) HttpStatusCode.InternalServerError);

                var opt = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(res, opt);

                await context.Response.WriteAsync(json);
            }
        }
    }
}