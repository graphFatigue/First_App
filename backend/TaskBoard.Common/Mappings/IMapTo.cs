using AutoMapper;

namespace TaskBoard.Common.Mappings
{
    public interface IMapTo<T>
    {
        void MapTo(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
