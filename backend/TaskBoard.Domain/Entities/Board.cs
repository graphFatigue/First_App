namespace TaskBoard.Domain.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<ListCards>? ListsCards { get; set; }
        public virtual ICollection<Card>? Cards { get; set; }
        public virtual ICollection<Action>? Actions { get; set; }
    }
}
