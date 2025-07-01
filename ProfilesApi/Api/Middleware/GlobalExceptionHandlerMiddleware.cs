using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Middleware;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhabdled exception");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        if (exception is NullReferenceException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new { error = exception.Message }));
        }
        else if (exception is BadHttpRequestException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new { error = exception.Message }));
        }
        else
        {
            httpContext.Response.StatusCode = StatusCodes.Status501NotImplemented;
            await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new { error = exception.Message }));
        }
        
    }
}