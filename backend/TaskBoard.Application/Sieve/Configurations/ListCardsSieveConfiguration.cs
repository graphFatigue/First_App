using Sieve.Services;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Application.Sieve.Configurations
{
    public class ListCardsSieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<ListCards>(x => x.Name)
                .CanFilter()
                .CanSort();
        }
    }
}
