using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BusDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PolskiBusDatabase")));

            return services;
        }
    }
}
