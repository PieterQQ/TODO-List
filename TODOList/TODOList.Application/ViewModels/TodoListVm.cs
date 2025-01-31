﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TODOList.Application.Mapping;
using TODOList.Domain.Model;
using static TODOList.Application.Mapping.IMapFrom;

namespace TODOList.Application.ViewModels
{
    public class TodoListVm:IMapFrom<TodoList>
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string ListName { get; set; }
        public TodoItemListVm Items { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoList, TodoListVm>()
                .ForMember(d => d.ListName, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Items, opt => opt.Ignore()).ReverseMap();
        }
    }
}
