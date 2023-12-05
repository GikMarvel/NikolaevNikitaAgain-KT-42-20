using NikolaevNikita_KT_42_20.Interfaces.IGroupInterfaces;
using NikolaevNikita_KT_42_20.Interfaces.StudentsInterfaces;

namespace NikolaevNikita_KT_42_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();

            return services;
        }
    }
}