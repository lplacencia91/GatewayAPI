
using Contracts;
using Entities;
using Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GatwQueryServices;
using LoggerService;

namespace Gatw.ServiceExtensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
services.AddScoped<ILoggerManaguer, LoggerManaguer>();
        public static void ConfigureSqlContext(this IServiceCollection services,
IConfiguration configuration) =>
services.AddDbContext<RepositoryContext>(opts =>opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
b.MigrationsAssembly("Gatw")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
services.AddScoped<IRepositoryManaguer, RepositoryManaguer>();

        public static void ConfigureGatewayQuery(this IServiceCollection services) =>
services.AddScoped<IGatewayServices, GatewayQueryServices>();

        public static void ConfigureDeviceQuery(this IServiceCollection services) =>
services.AddScoped<IDeviceServices, DeviceQueryServices>();

    }

    
}
