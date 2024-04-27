using Sieve.Services;
using TaskBoard.Common.Models.Card;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Application.Sieve.Configurations
{
    public class CardSieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Card>(x => x.Name)
                .CanFilter()
                .CanSort();

            mapper.Property<CardModel>(x => x.ListCardsName)
                .CanFilter()
                .CanSort();

            mapper.Property<Card>(x => x.Priority)
                .CanFilter()
                .CanSort();

            mapper.Property<Card>(x => x.DueDate)
                .CanFilter()
                .CanSort();

            mapper.Property<Card>(x => x.ListCardsId)
                .CanFilter()
                .CanSort();
        }
    }
}
