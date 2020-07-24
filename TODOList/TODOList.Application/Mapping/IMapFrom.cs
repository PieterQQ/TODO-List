using AutoMapper;

namespace TODOList.Application.Mapping
{
    public interface IMapFrom
    {
        public interface IMapFrom<T>
        {
            void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
        }
    }
}
