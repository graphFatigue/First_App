using AutoMapper;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Mappings;

namespace TaskBoard.Common.Models.Action
{
    public class ActionModel : IMapFrom<Domain.Entities.Action>
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime? ActionTime { get; set; }
        public int BoardId { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Action, ActionModel>()
                .ForMember(dest => dest.ActionTime, src => src.MapFrom(opt => opt.ActionTime.ToFileTimeUtc()));
        }
    }
}
