using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TaskBoard.Infrastructure;

namespace TaskBoard.Tests.IntegrationTests
{
    internal class TaskBoardWebApplicationFactory: WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<AppDbContext>));

                var connString = "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=cards_db_test;";

                services.AddNpgsql<AppDbContext>(connString);

                AppDbContext dbContext = CreateDbContext(services);
                dbContext.Database.EnsureDeleted();
            });
        }

        private static AppDbContext CreateDbContext(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            return dbContext;
        }
    }
}
