using Microsoft.AspNetCore.Http;
using System;

using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.ErrorHandlingLogic
{
    public static class ErrorHandling
    {
        public static async Task HandleError(HttpContext context, object errors)
        {
            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var result = JsonSerializer.Serialize(new
                {
                    errors
                });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
