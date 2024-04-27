using Sieve.Services;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Application.Sieve.Configurations
{
    internal class ListCardsSieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<ListCards>(x => x.Name)
                .CanFilter()
                .CanSort();
        }
    }
}
