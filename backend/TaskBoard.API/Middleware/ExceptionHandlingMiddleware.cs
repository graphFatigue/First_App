using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Newtonsoft.Json;
using Npgsql;
using TaskBoard.Common.Exceptions;

namespace TaskBoard.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(
            RequestDelegate next)
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
            var code = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                NpgsqlException => StatusCodes.Status400BadRequest,
                BadRequestException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = exception.Message }));
        }
    }
}
