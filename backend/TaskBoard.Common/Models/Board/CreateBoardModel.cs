using TaskBoard.Common.Mappings;

namespace TaskBoard.Common.Models.Board
{
    public class CreateBoardModel : IMapTo<Domain.Entities.Board>
    {
        public string? Name { get; set; }
    }
}
