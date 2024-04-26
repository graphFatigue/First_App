using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;
using TaskBoard.Infrastructure.Extensions;

namespace TaskBoard.Infrastructure.Initializers
{
    internal static class CardDataInitializer
    {
        internal static void SeedData(ModelBuilder builder)
        {
            builder.Entity<Card>().HasData
            (
                new Card()
                {
                    Id = 1,
                    Name = "Do QA",
                    Description = "Necessary QA job for the website",
                    Priority = Domain.Enum.Priority.Medium,
                    DueDate = new DateTime(2024, 05, 15).SetKindUtc()
                },
                new Card()
                {
                    Id = 2,
                    Name = "Fix the bug with the slider on the main page",
                    Description = "The slider is displaying images with numbers 3,6,8 inappropriately",
                    Priority = Domain.Enum.Priority.High,
                    DueDate = new DateTime(2024, 05, 8).SetKindUtc()
                },
                new Card()
                {
                    Id = 3,
                    Name = "Change the design of the navbar",
                    Description = "The font must be Arial and the main color must be purple",
                    Priority = Domain.Enum.Priority.Low,
                    DueDate = new DateTime(2024, 05, 30).SetKindUtc()
                },
                new Card()
                {
                    Id = 4,
                    Name = "Change the design of the sidebar",
                    Description = "The font must be Arial and the main color must be purple",
                    Priority = Domain.Enum.Priority.Low,
                    DueDate = new DateTime(2024, 05, 30).SetKindUtc()
                },
                new Card()
                {
                    Id = 5,
                    Name = "Fix the bug with the description of products",
                    Description = "The description of products on the page 9 can't be changed",
                    Priority = Domain.Enum.Priority.High,
                    DueDate = new DateTime(2024, 05, 4).SetKindUtc()
                }
            );
        }
    }
}
