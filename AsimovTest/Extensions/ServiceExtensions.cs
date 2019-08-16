using BusinessRules;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsimovTest.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(option =>
                option.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureRepositoriesWrappers(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryModelsWrapper, RepositoryModelsWrapper>();
        }

        public static void ConfigureBusinessRules(this IServiceCollection services)
        {
            services.AddScoped<DeathDateBR>();
        }
    }
}
