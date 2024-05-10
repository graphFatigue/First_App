using TaskBoard.Domain.Enum;

namespace TaskBoard.Domain.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime ActionTime { get; set; }
        public int? CardId { get; set; }
        public virtual Card? Card { get; set; }
        public int? BoardId { get; set; }
        public virtual Board? Board { get; set; }
    }
}
