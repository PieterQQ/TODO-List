using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TODOList.Application.ViewModels;

namespace TODOList.Application.Interfaces
{
    public interface ITodoServices
    {
        Task<TodoListListVm> GetAllTodoLists();
        Task<TodoListVm> GetTodoListsById(int id);
        Task<TodoItemListVm> GetTodoItemsForList(int listId);
        Task<TodoItemListVm> GetAllTodoItems(int id);
        Task<int> InsertTodoList(TodoListVm todoList);
        Task DeleteTodoList(int todolistid);
     
        Task<int> InsertTodoItem(TodoItemVm todoItem);
        Task DeleteTodoItem(int todoItemid);
        Task UpdateTodoItem(TodoItemVm todoItem);
    

    }
}
