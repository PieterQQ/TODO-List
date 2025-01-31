﻿using AutoMapper;
using System;
using TODOList.Domain.Model;
using static TODOList.Application.Mapping.IMapFrom;

namespace TODOList.Application.ViewModels
{
    public class TodoItemVm : IMapFrom<TodoItem>
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int TodoListId { get; set; }
        public string TodoListName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoItem, TodoItemVm>()
                .ForMember(d => d.TodoListName, opt => opt.MapFrom(s => s.TodoListName)).ReverseMap();
        }
    }
}
