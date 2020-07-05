using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Domain.Interfaces;
using TODOList.Domain.Model;

namespace TODOList.Infrastructure.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly Context _context;
        public TodoListRepository(Context context)
        {
            _context = context;
        }
        public async Task DeleteTodoList(int todolistid)
        {
            var ToDelete =  _context.TodoLists.Where(x => x.Id == todolistid).SingleOrDefault();
            _context.TodoLists.Remove(ToDelete);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TodoList> GetAll()
        {
            return _context.TodoLists;
        }

        public TodoList GetListById(int id)
        {
            return _context.TodoLists.FirstOrDefault(x => x.Id == id);
        }

        public async Task<int> InsertTodoList(TodoList todoList)
        {
            await _context.TodoLists.AddAsync(todoList);
            await _context.SaveChangesAsync();
            return todoList.Id;
        }

        public async Task UpdateTodoList(TodoList todoList)
        {
            _context.Update(todoList);
            await _context.SaveChangesAsync();
        }
    }
}
