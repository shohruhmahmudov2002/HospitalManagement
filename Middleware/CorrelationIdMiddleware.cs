using HospitalManagement.CGenerator;

namespace HospitalManagement.Middleware;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private const string _correlationIdHeader = "X-Correlation-Id";
    private readonly ILogger<CorrelationIdMiddleware> _logger;
    public CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, ICorrelationIdGenerator correlationIdGenerator)
    {
        var correlationId = GetCorrelationIdTrace(context, correlationIdGenerator);
        AddCorrelationIdToResponse(context, correlationId);

        using (_logger.BeginScope(correlationId))
        {
            await _next(context);
        }
    }
    private static string GetCorrelationIdTrace(HttpContext context, ICorrelationIdGenerator correlationIdGenerator)
    {
        if (context.Request.Headers.TryGetValue(_correlationIdHeader, out var correlationId))
        {
            correlationIdGenerator.Set(correlationId);
            return correlationId;
        }
        else
        {
            return correlationIdGenerator.Get();
        }
    }
    private static void AddCorrelationIdToResponse(HttpContext context, string correlationId)
    {
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Add(_correlationIdHeader, new[] {correlationId});
            return Task.CompletedTask;
        });
    }
}
