using AutoMapper;
using TaskBoard.Common.Mappings;
using TaskBoard.Common.Models.Card;
using TaskBoard.Common.Models.ListCards;

namespace TaskBoard.Common.Models.Board
{
    public class BoardModel : IMapFrom<Domain.Entities.Board>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<CardModel>? Cards { get; set; }
        public ICollection<ListCardsModel>? ListsCards { get; set; }
        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Board, BoardModel>()
                .ForMember(dest => dest.Cards, src => src.MapFrom(opt => opt.Cards))
                .ForMember(dest => dest.ListsCards, src => src.MapFrom(opt => opt.ListsCards));
        }
    }
}
