using Microsoft.Extensions.Options;

namespace HospitalManagement.Middleware;

public class ExceptionMiddleware: IMiddleware
{
    private ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate _next)
    {
        try
        {
            await _next(context);
        }
        catch (OptionsValidationException ex)
        {
            _logger.LogError(ex, "Options validation failed");
            throw new InvalidOperationException("Options validation failed");
        }
    }
}
