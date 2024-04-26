using AutoMapper;

namespace TaskBoard.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void MapFrom(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
