namespace TaskBoard.Domain.Entities
{
    public class ListCards
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BoardId { get; set; }
        public virtual Board? Board { get; set; }
        public virtual ICollection<Card>? Cards { get; set; }
    }
}
