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
                    Name = "Wash the dishes",
                    Description = "You need to wash the dishes",
                    Priority = Domain.Enum.Priority.Medium,
                    DueDate = new DateTime(2024, 05, 15).SetKindUtc(),
                    ListCardsId = 1,
                },
                new Card()
                {
                    Id = 2,
                    Name = "Do laundry",
                    Description = "You need to do the launry!!",
                    Priority = Domain.Enum.Priority.High,
                    DueDate = new DateTime(2024, 05, 28).SetKindUtc(),
                    ListCardsId = 2
                },
                new Card()
                {
                    Id = 3,
                    Name = "Plan your vacation",
                    Description = "You need to plan your summer vacation",
                    Priority = Domain.Enum.Priority.Low,
                    DueDate = new DateTime(2024, 05, 30).SetKindUtc(),
                    ListCardsId = 1
                },
                new Card()
                {
                    Id = 4,
                    Name = "Give away the old cloth",
                    Description = "You really need to give away your old cloth",
                    Priority = Domain.Enum.Priority.Low,
                    DueDate = new DateTime(2024, 05, 30).SetKindUtc(),
                    ListCardsId = 2
                },
                new Card()
                {
                    Id = 5,
                    Name = "Find something to wear this evening",
                    Description = "You're going to celebrate your promotion",
                    Priority = Domain.Enum.Priority.High,
                    DueDate = new DateTime(2024, 07, 4).SetKindUtc(),
                    ListCardsId = 1
                },
                new Card()
                {
                    Id = 6,
                    Name = "Buy new shoes",
                    Description = "You've seen a great pair of shoes tomorrow at the shop",
                    Priority = Domain.Enum.Priority.Medium,
                    DueDate = new DateTime(2024, 05, 15).SetKindUtc(),
                    ListCardsId = 2,
                },
                new Card()
                {
                    Id = 7,
                    Name = "Buy groceries",
                    Description = "You have nothing to eat",
                    Priority = Domain.Enum.Priority.High,
                    DueDate = new DateTime(2024, 05, 20).SetKindUtc(),
                    ListCardsId = 1
                },
                new Card()
                {
                    Id = 8,
                    Name = "Call your mother",
                    Description = "You need to return call!!",
                    Priority = Domain.Enum.Priority.Low,
                    DueDate = new DateTime(2024, 05, 30).SetKindUtc(),
                    ListCardsId = 2
                },
                new Card()
                {
                    Id = 9,
                    Name = "Schedule an appointment with the doctor",
                    Description = "You've been feeling really under the weather lately",
                    Priority = Domain.Enum.Priority.Low,
                    DueDate = new DateTime(2024, 05, 30).SetKindUtc(),
                    ListCardsId = 1
                },
                new Card()
                {
                    Id = 10,
                    Name = "Go for a walk with your friend",
                    Description = "Long time no see!",
                    Priority = Domain.Enum.Priority.High,
                    DueDate = new DateTime(2024, 06, 08).SetKindUtc(),
                    ListCardsId = 2
                }
            );
        }
    }
}
