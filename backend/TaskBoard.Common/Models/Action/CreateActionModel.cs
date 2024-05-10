using TaskBoard.Common.Mappings;
using TaskBoard.Domain.Enum;

namespace TaskBoard.Common.Models.Action
{
    public class CreateActionModel : IMapTo<Domain.Entities.Action>
    {
        public string? Message { get; set; }
        public DateTime ActionTime { get; set; }
        public int CardId { get; set; }
        public int BoardId { get; set; }
    }
}
