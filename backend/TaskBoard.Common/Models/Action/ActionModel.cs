using AutoMapper;
using TaskBoard.Common.Mappings;

namespace TaskBoard.Common.Models.Action
{
    public class ActionModel : IMapFrom<Domain.Entities.Action>
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? CardName { get; set; }
        public string? ListCardsName { get; set; }
        public DateTime ActionTime { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Action, ActionModel>()
                .ForMember(dest => dest.CardName, src => src.MapFrom(opt => opt.Card.Name))
                .ForMember(dest => dest.ListCardsName, src => src.MapFrom(opt => opt.ListCards.Name))
                .ForMember(dest => dest.Message, src => src.MapFrom(opt => opt.ActionType.ToString().Concat(opt.Card.Name)));
        }
    }
}
