
namespace e_Kart;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            _logger.LogError($"{exception.GetType().ToString()}:{exception.Message}");

            if (exception.InnerException is not null)
            {
                _logger.LogError($"{exception.InnerException.GetType().ToString()}:{exception.InnerException.Message}");
            }

            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                Message = exception.Message,
                Type = exception.GetType().ToString()
            });
        }

    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
