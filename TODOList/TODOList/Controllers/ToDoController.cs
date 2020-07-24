using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TODOList.Application.Interfaces;
using TODOList.Application.ViewModels;

namespace TODOList.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _service;
        public TodoController(ITodoService service)
        {
            _service = service;
        }
        // GET: TodoController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllTodoLists();
            return View(model);
        }

        // GET: TodoController/Details/5
        public async Task<ActionResult> ListDetails(int id)
        {
            var model = await _service.GetTodoItemsForList(id);
            return View(model);
        }

        // GET: TodoController/Create
        public ActionResult CreateList()
        {
            return View();
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateList(IFormCollection collection, TodoListVm model)
        {
            try
            {
                await _service.InsertTodoList(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/RenameList/5
        public ActionResult RenameList(int id)
        {
            var model = _service.GetTodoListById(id).Result;
            return View(model);
        }

        // POST: TodoController/RenameList/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RenameList(IFormCollection collection, TodoListVm model)
        {
            try
            {
                await _service.UpdateTodoList(model);
                return RedirectToAction(nameof(ListDetails), new { id = model.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/DeleteList/5
        public async Task<ActionResult> DeleteList(int id)
        {
            for (int listLength = _service.GetTodoItemsForList(id).Result.Count; listLength > 0; --listLength)
            {

                int itemId = _service.GetTodoItemsForList(id).Result.Items.FirstOrDefault().Id;
                await DeleteItem(itemId);
            }

            await _service.DeleteTodoList(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: TodoController/CreateItem?ListId=5
        public ActionResult CreateItem(int listId)
        {
            var model = new TodoItemVm
            {
                TodoListId = listId,
                TodoListName = _service.GetTodoListById(listId).Result.ListName
            };
            return View(model);
        }

        // POST: TodoController/CreateItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateItem(IFormCollection collection, TodoItemVm model)
        {
            try
            {
                await _service.InsertTodoItem(model);
                return RedirectToAction(nameof(ListDetails), new { id = model.TodoListId });
            }
            catch
            {
                return View();
            }
        }

        //GET: TodoController/EditItem/5
        public ActionResult EditItem(int id)
        {
            var model = _service.GetAllTodoItems().Result.Items.Find(item => item.Id == id);
            return View(model);
        }

        // POST: TodoController/UpdateItem/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditItem(IFormCollection collection, TodoItemVm model)
        {
            try
            {
                int listId = model.TodoListId;
                string listName = _service.GetTodoListById(listId).Result.ListName;
                model.TodoListName = listName;
                await _service.UpdateTodoItem(model);
                return RedirectToAction(nameof(ListDetails), new { id = listId });
            }
            catch
            {
                return View();
            }
        }
        private async Task DeleteItem(int id)
        {
            await _service.DeleteTodoItem(id);
        }

        //GET: TodoController/DeleteItemAndReturnToIndex/5
        public async Task<ActionResult> DeleteItemAndReturnToIndex(int id)
        {
            await DeleteItem(id);
            return RedirectToAction(nameof(Index));
        }

        //GET: TodoController/DeleteItemAndReturnToListDetails/5
        public async Task<ActionResult> DeleteItemAndReturnToListDetails(int id)
        {
            int listId = _service.GetAllTodoItems().Result.Items.Find(item => item.Id == id).TodoListId;
            await DeleteItem(id);
            return RedirectToAction(nameof(ListDetails), new { id = listId });
        }
    }
}
