using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Infrastructure.Initializers
{
    internal class BoardDataInitializer
    {
        internal static void SeedData(ModelBuilder builder)
        {
            builder.Entity<Board>().HasData
            (
                new Board()
                {
                    Id = 1,
                    Name = "Family board",
                },
                new Board()
                {
                    Id = 2,
                    Name = "My board",
                });
        }
    }
}
