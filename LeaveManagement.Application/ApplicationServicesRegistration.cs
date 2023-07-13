using LeaveManagement.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
