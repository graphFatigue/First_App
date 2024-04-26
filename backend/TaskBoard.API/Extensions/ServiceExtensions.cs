using Microsoft.EntityFrameworkCore;
using TaskBoard.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using TaskBoard.API.Validators.Card;
using TaskBoard.API.Validators.ListCards;

namespace TaskBoard.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigurePostgresSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                    .UseNpgsql(configuration.GetConnectionString("DatabaseConnection"));
            });
        }


        public static void ConfigureFluentValidation(
            this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateCardModelValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCardModelValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateListCardsModelValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateListCardsModelValidator>();
        }
    }
}
