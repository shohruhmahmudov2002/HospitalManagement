using HospitalManagement.DataAccess;
using HospitalManagement.Repository;
using HospitalManagement.Repository.Interfaces;
using HospitalManagement.Service;
using HospitalManagement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();


            services.AddSingleton<PdpService>();

            return services;
        }
    }
}
