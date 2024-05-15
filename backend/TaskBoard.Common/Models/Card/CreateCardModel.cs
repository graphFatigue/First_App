using TaskBoard.Common.Mappings;

namespace TaskBoard.Common.Models.Card
{
    public class CreateCardModel : IMapTo<Domain.Entities.Card>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? Priority { get; set; }
        public string? ListCardsName { get; set; }
        public int BoardId { get; set; }
    }
}
