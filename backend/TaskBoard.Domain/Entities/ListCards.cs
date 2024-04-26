namespace TaskBoard.Domain.Entities
{
    public class ListCards
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Card>? Cards { get; set; }
    }
}
