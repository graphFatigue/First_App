using TaskBoard.Domain.Enum;

namespace TaskBoard.Domain.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime ActionTime { get; set; }
        public int? CardId { get; set; }
        public virtual Card? Card { get; set; }
        public int? ListCardsId { get; set; }
        public virtual ListCards? ListCards { get; set; }
    }
}
