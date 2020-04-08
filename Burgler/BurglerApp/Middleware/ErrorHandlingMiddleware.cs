using Burgler.BusinessLogic.ErrorHandlingLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BurglerApp.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
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
                object errors = null;

                switch (ex)
                {
                    case RestException re:
                        //_logger.LogError(ex, "REST ERROR");
                        errors = re.Errors;
                        context.Response.StatusCode = (int)re.Code;
                        break;
                    case Exception e:
                        _logger.LogError(ex, "SERVER ERROR");
                        errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                await ErrorHandling.HandleError(context, errors);
            }
        }
    }
}
