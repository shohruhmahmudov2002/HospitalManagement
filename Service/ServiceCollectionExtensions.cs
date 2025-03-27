using HospitalManagement.CGenerator;

namespace HospitalManagement.Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
    {
        services.AddSingleton<ICorrelationIdGenerator, CorrelationIdGenerator>();
        return services;
    }
}
