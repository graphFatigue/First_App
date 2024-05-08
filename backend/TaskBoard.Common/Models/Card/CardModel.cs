using AutoMapper;
using TaskBoard.Common.Mappings;
using TaskBoard.Common.Models.Action;
using TaskBoard.Common.Models.ListCards;

namespace TaskBoard.Common.Models.Card
{
    public class CardModel: IMapFrom<Domain.Entities.Card>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? Priority { get; set; }
        public string? ListCardsName { get; set; }
        public ICollection<ActionModel>? Actions { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Card, CardModel>()
                .ForMember(dest => dest.ListCardsName, src => src.MapFrom(opt => opt.ListCards.Name))
                .ForMember(dest => dest.Actions, src => src.MapFrom(opt => opt.Actions))
                .ForMember(dest => dest.Priority, src => src.MapFrom(opt => opt.Priority.ToString()));
        }
    }
}
