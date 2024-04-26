using Sieve.Services;
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

            mapper.Property<Card>(x => x.Priority)
                .CanFilter()
                .CanSort();

            mapper.Property<Card>(x => x.DueDate)
                .CanFilter()
                .CanSort();
        }
    }
}
