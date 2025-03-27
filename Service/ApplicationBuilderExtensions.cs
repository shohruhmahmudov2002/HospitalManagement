using HospitalManagement.Middleware;

namespace HospitalManagement.Service;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder AppCorrelationIdMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<CorrelationIdMiddleware>();
    }
}
