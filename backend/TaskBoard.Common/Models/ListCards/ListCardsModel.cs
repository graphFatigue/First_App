using AutoMapper;
using TaskBoard.Common.Mappings;
using TaskBoard.Common.Models.Action;
using TaskBoard.Common.Models.Card;

namespace TaskBoard.Common.Models.ListCards
{
    public class ListCardsModel : IMapFrom<Domain.Entities.ListCards>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<CardModel>? Cards { get; set; }
        public int BoardId { get; set; }
        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Domain.Entities.ListCards, ListCardsModel>()
                .ForMember(dest => dest.BoardId, src => src.MapFrom(opt => opt.Board.Id))
                .ForMember(dest => dest.Cards, src => src.MapFrom(opt => opt.Cards));
        }
    }
}
