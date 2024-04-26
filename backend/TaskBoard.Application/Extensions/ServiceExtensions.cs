using Microsoft.Extensions.DependencyInjection;
using Sieve.Models;
using Sieve.Services;
using System.Reflection;
using TaskBoard.Abstractions.Application;
using TaskBoard.Application.Services;
using TaskBoard.Application.Sieve;
using TaskBoard.Common.Mappings;

namespace TaskBoard.Application.Extensions
{
    public static class DependencyRegistrar
    {
        public static IServiceCollection ConfigureBusinessLayerServices(
            this IServiceCollection services)
        {
            services.ConfigureAutomapper();

            services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
            services.AddScoped<ICardService, CardService>();
            //services.AddScoped<IListCardsService, ListCardsService>();
            //services.AddScoped<IActionService, ActionService>();
            services.Configure<SieveOptions>(options => options.CaseSensitive = false);

            return services;
        }

        private static IServiceCollection ConfigureAutomapper(
            this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            return services;
        }
    }
}
