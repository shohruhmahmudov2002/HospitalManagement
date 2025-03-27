
using HospitalManagement.DataAccess;
using HospitalManagement.DTOs;
using HospitalManagement.Extensions;
using HospitalManagement.Middleware;
using HospitalManagement.Service;
using HospitalManagement.Settings;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HospitalManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<ExceptionMiddleware>();

            builder.Services.AddDependencies(); 

            builder.Services.AddMemoryCache();

            var configuration = builder.Configuration;

            //var connectionString1 = configuration["ConnectionStrings:DefaultConnection"];
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            builder.Services.AddDbContext<HospitalContext>(options =>
            {
                options.UseNpgsql(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .UseSnakeCaseNamingConvention();
            });

            //var pdpSettings = configuration.GetSection("PdpSettings");
            //var pdpSettingEndpoint = configuration.GetSection("PdpSettings:Endpoint");

            //var endpoint = pdpSettings.GetSection("Endpoint").Value;

            //var children = pdpSettings.GetChildren();

            builder.Services.AddHttpClient();
            builder.Services.Configure<PdpSetting>(configuration.GetSection("PdpSettings"));

            
            builder.Services.Configure<DoctorSetting>(configuration.GetSection("DoctorsSettings"));

            builder.Services.Configure<AppointmentSetting>(configuration.GetSection("AppointmentSettings"));

            builder.Services.AddSerilog((serviceProvider, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(configuration);
            });

            builder.Services.AddOptions<PdpSetting>().
                ValidateDataAnnotations();

            builder.Services.AddCorrelationIdGenerator();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();
            app.AppCorrelationIdMiddleware();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<GlobalLoggingMiddleware>();

            app.MapControllers();

            app.Run(); 
            
        }
    }
}
