using Sieve.Services;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Application.Sieve.Configurations
{
    public class ActionSieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Domain.Entities.Action>(x => x.ActionTime)
                .CanFilter()
                .CanSort();
        }
    }
}
