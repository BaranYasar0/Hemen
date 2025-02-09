using Hemen.Infrastructure.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Hemen.Infrastructure.Exceptions;
public class GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> _logger) {

    public async Task Invoke(HttpContext context) {
        try {
            await next(context);
        }
        catch (Exception ex) {
            var result = HandleException(ex);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = result.StatusCode;

            var jsonResponse = JsonSerializer.Serialize(result.Result);
            await context.Response.WriteAsync(jsonResponse);
        }
    }

    private (BaseApiResult<object> Result, int StatusCode) HandleException(Exception ex) {

        _logger.LogError(ex, "An error occurred while processing the request.");

        return ex switch {
            UnauthorizedAccessException => (BaseApiResult<object>.ErrorAsUnauthorized(), (int)HttpStatusCode.NotFound),
            KeyNotFoundException => (BaseApiResult<object>.ErrorAsNotFound(), (int)HttpStatusCode.NotFound),
            InvalidOperationException => (BaseApiResult<object>.Error(ex.Message, ex.InnerException?.Message, HttpStatusCode.BadRequest), (int)HttpStatusCode.BadRequest),
            _ => (BaseApiResult<object>.ErrorFromException(ex), (int)HttpStatusCode.InternalServerError)
        };
    }
}
