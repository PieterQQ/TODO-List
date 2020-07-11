using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODOList.Application.Interfaces;
using TODOList.Application.ViewModels;

namespace TODOList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoServices _services;
        public ToDoController(ITodoServices services)
        {
            _services = services;
        }
        // GET: ToDoController
        public async Task<ActionResult> Index()
        {
            var model = await _services.GetAllTodoLists();
            return View(model);
        }

        // GET: ToDoController/Details/5
        public async Task<ActionResult> ListDetails(int id)
        {
            var model = await _services.GetTodoItemsForList(id);
            return View(model);
        }

        // GET: ToDoController/Create
        public ActionResult CreateList()
        {
            return View();
        }

        // POST: ToDoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateList(IFormCollection collection,TodoListVm model)
        {
            try
            {
                await _services.InsertTodoList(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Delete/5
        public async Task<ActionResult> DeleteItem(int id)
        {
            await _services.DeleteTodoItem(id);
            return View();
        }

        
    }
}
