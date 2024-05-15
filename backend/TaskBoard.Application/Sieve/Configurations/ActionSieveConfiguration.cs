using Sieve.Services;

namespace TaskBoard.Application.Sieve.Configurations
{
    public class ActionSieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Domain.Entities.Action>(x => x.ActionTime)
                .CanFilter()
                .CanSort();

            mapper.Property<Domain.Entities.Action>(x => x.CardId)
                .CanFilter()
                .CanSort();

            mapper.Property<Domain.Entities.Action>(x => x.BoardId)
                .CanFilter()
                .CanSort();

            mapper.Property<Domain.Entities.Action>(x => x.Message)
                .CanFilter()
                .CanSort();

            mapper.Property<Domain.Entities.Action>(x => x.Id)
                .CanFilter()
                .CanSort();
        }
    }
}
