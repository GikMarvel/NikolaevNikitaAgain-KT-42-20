using Microsoft.Identity.Client;
using NikolaevNikita_KT_42_20.Interfaces.StudentsInterfaces;

namespace NikolaevNikita_KT_42_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
} 