using AutoMapper;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

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
