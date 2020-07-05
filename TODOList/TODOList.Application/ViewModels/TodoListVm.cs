using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TODOList.Application.Mapping;
using TODOList.Domain.Model;
using static TODOList.Application.Mapping.IMapFrom;

namespace TODOList.Application.ViewModels
{
    public class TodoListVm:IMapFrom<TodoList>
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoList, TodoListVm>().ReverseMap();
        }
    }
}
