using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApp
{
    public class RoutingMiddleWare
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if(path == "/index")
            {
                await context.Response.WriteAsync("Home page");
            }
            else if(path == "/about")
            {
                await context.Response.WriteAsync("About");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
