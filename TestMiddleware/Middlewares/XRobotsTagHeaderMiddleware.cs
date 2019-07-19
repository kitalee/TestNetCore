using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace TestMiddleware.Middlewares
{
    public class XRobotsTagHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public XRobotsTagHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            IHeaderDictionary headers = context.Response.Headers;
            headers["X-Robots-Tag"] = "noindex";
            await _next(context);
        }
    }

    public static class XRobotsTagHeaderMiddlewareExtension
    {
        public static IApplicationBuilder UseXRobotsTagHeaderMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<XRobotsTagHeaderMiddleware>();
        }
    }
}
