using Abstractions.Handlers;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Abstractions.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly Func<Task> _next;
        private readonly HttpContext _context;

        public ErrorMiddleware(HttpContext context, Func<Task> next)
        {
            _next = next;
            _context = context;
        }

        public async Task Invoke()
        {
            try
            {
                await _next();
            }
            catch (Exception ex)
            {
                await ExceptionHandler.HandleAsync(_context, ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
