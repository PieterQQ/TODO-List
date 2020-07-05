using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TODOList.Application.Interfaces;
using TODOList.Application.ViewModels;
using TODOList.Domain.Interfaces;
using TODOList.Infrastructure.Repositories;

namespace TODOList.Application.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly ITodoItemRepository _itemrepo;
        private readonly ITodoListRepository _listRepo;
        private readonly IMapper _mapper;
        public TodoServices(ITodoItemRepository itemrepo, ITodoListRepository listRepo, IMapper mapper)
        {
            _itemrepo = itemrepo;
            _listRepo = listRepo;
            _mapper = mapper;
        }

        public async Task DeleteTodoItem(int todoItemid)
        {
            await _itemrepo.DeleteTodoItem(todoItemid);
        }

        public async Task DeleteTodoList(int todolistid)
        {
            await _listRepo.DeleteTodoList(todolistid);
        }

        public async Task<TodoItemListVm> GetAllTodoItems(int id)
        {
            var items = await _itemrepo.GetAll().ProjectTo<TodoItemVm>(_mapper.ConfigurationProvider).ToListAsync();
            return new TodoItemListVm()
            {
                Items = items,
                Count = items.Count
            };
        }

        public async Task<TodoListListVm> GetAllTodoLists()
        {
          var lists=await _listRepo.GetAll().ProjectTo<TodoListVm>(_mapper.ConfigurationProvider).ToListAsync();
            return new TodoListListVm()
            {
              Lists=lists,
              Count=lists.Count
            };
        }

        public async Task<TodoItemListVm> GetTodoItemsForList(int listId)
        {
            var items = await _itemrepo.GetTodoItemsForList(listId).ProjectTo<TodoItemVm>(_mapper.ConfigurationProvider).ToListAsync();
            return new TodoItemListVm()
            {
                Items = items,
                Count = items.Count
            };
        }

        public async Task<TodoListVm> GetTodoListsById(int id)
        {
            var list = await _listRepo.GetListById(id).ProjectTo<TodoListVm>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return new TodoListListVm()
            {
                Lists = lists,
                Count = lists.Count
            };
        }

        public Task<int> InsertTodoItem(TodoItemVm todoItem)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertTodoList(TodoListVm todoList)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTodoItem(TodoItemVm todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
