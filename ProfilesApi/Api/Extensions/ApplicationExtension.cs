
using Api.Middleware;

namespace Api.Extensions;

public static class ApplicationExtensions
{
    public static void ConfigureMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}