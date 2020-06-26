using System;
using System.Collections.Generic;
using System.Text;
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
        public TodoServices(ITodoItemRepository itemrepo,ITodoListRepository listRepo)
        {
            _itemrepo = itemrepo;
            _listRepo = listRepo;
        }
        public List<TodoListVm> GetListWithItems()
        {
            var lists = _listRepo.GetAll();
            var items = _itemrepo.GetAll();
        }
    }
}
