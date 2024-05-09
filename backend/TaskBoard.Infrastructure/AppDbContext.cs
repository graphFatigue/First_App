using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;
using TaskBoard.Infrastructure.Configuration;
using TaskBoard.Infrastructure.Initializers;
using Action = TaskBoard.Domain.Entities.Action;

namespace TaskBoard.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        static AppDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ListCardsConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActionConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoardConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
            CardDataInitializer.SeedData(modelBuilder);
            ListCardsDataInitializer.SeedData(modelBuilder);
            BoardDataInitializer.SeedData(modelBuilder);
        }

        public DbSet<Card>? Cards { get; set; }
        public DbSet<Board>? Boards { get; set; }
        public DbSet<Action>? Actions { get; set; }
        public DbSet<ListCards>? ListCards { get; set; }
    }
}
