using Microsoft.Extensions.DependencyInjection;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Infrastructure.Repositories;

namespace TaskBoard.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureDataAccessLayer(
            this IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IListCardsRepository, ListCardsRepository>();
            services.AddScoped<IActionRepository, ActionRepository>();

            return services;
        }
    }
}
