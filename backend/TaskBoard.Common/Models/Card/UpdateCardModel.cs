using AutoMapper;

namespace TaskBoard.Common.Models.Card
{
    public class UpdateCardModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? Priority { get; set; }
        public string? ListCardsName { get; set; }
        public virtual Domain.Entities.ListCards? ListCards { get; set; }
        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Card, UpdateCardModel>()
                .ForMember(dest => dest.ListCardsName, src => src.MapFrom(opt => opt.ListCards.Name))
                .ForMember(dest => dest.Priority, src => src.MapFrom(opt => opt.Priority.ToString()));
        }
    }
}
