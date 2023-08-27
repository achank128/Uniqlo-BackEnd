using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Models.Models;

namespace Uniqlo.Middlewares
{
    public class GlobalException : IMiddleware
    {
        private readonly ILogger<GlobalException> _logger;

        public GlobalException(ILogger<GlobalException> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = StatusCodes.Status500InternalServerError;

            code = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                BadRequestException => StatusCodes.Status400BadRequest,
                ForbiddenException => StatusCodes.Status403Forbidden,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                UnprocessableRequestException => StatusCodes.Status422UnprocessableEntity,
                _ => code
            };

            var result = ApiResponse<string>.Failure(code, exception.Message).ToString();

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(result);
        }
    }
}
