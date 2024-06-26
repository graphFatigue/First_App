﻿using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Infrastructure.Initializers
{
    internal class ListCardsDataInitializer
    {
        internal static void SeedData(ModelBuilder builder)
        {
            builder.Entity<ListCards>().HasData
            (
                new ListCards()
                {
                    Id = 1,
                    Name = "Planned",
                    BoardId = 1,
                },
                new ListCards()
                {
                    Id = 2,
                    Name = "To Do",
                    BoardId = 2,
                });
        }
    }
}
