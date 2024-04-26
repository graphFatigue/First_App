using TaskBoard.Domain.Enum;

namespace TaskBoard.Domain.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public int? ListCardsId { get; set; } 
        public virtual ListCards? ListCards { get; set; }
    }
}
