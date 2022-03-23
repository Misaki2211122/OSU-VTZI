using Application.Abstractions.Database;
using Application.Domains.Entities;
using Database.Context;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database;

public static class ServiceCollection
{
    public static void AddInfrastructureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<IOsuVtziContext,OsuVtziContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DBConnection"),
                new MySqlServerVersion(new Version(5, 6, 45))));
            
        services.AddTransient<IRepository<AdminEntity>, AdminRespository>();
        
    }
}