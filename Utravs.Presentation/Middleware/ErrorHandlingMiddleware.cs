﻿using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json;

namespace Utravs.Presentation.Middleware
{

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; 
            string result;

            if (exception is FluentValidation.ValidationException validationException)
            {
                code = HttpStatusCode.BadRequest; 
                result = JsonConvert.SerializeObject(new
                {
                    message = "Validation error",
                    errors = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                });
            }
            else if (exception is InvalidOperationException invalidOperationException)
            {
                code = HttpStatusCode.BadRequest; 
                result = JsonConvert.SerializeObject(new
                {
                    message = invalidOperationException.Message
                });
            }
            else
            {
                result = JsonConvert.SerializeObject(new { message = "An unexpected error occurred." });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }

    }

}
