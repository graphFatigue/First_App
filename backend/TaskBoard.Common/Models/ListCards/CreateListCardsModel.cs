using TaskBoard.Common.Mappings;

namespace TaskBoard.Common.Models.ListCards
{
    public class CreateListCardsModel : IMapTo<Domain.Entities.ListCards>
    {
        public string? Name { get; set; }
        public int BoardId { get; set; }
    }
}
