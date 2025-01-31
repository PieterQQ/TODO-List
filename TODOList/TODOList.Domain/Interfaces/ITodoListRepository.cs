﻿using System.Linq;
using System.Threading.Tasks;
using TODOList.Domain.Model;

namespace TODOList.Domain.Interfaces
{
    public interface ITodoListRepository
    {
        IQueryable<TodoList> GetAll();
        TodoList GetListById(int id);
        Task<int> InsertTodoList(TodoList todoList);
        Task DeleteTodoList(int todoListid);
        Task UpdateTodoList(TodoList todoList);
    }
}
