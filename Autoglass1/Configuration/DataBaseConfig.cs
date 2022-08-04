using System;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configuration
{
    public static class DataBaseConfig
    {
        private const string AppSettingsConnString = "DefaultConnection";
        private const string MigrationsProject = "Infrastructure";
        public static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DomainDbContext>(
                o => o.UseMySql(configuration.GetConnectionString(AppSettingsConnString), new MySqlServerVersion(new Version(8, 0, 29)),
                    x => x.MigrationsAssembly(MigrationsProject)
                        .CommandTimeout(120)));
        }
    }
}
