using Microsoft.AspNetCore.Mvc;
using System;
using TodoList.Models;
using TodoList.Services;
using TodoList.ViewModel;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoServis todoServis;

        public TodoController(ITodoServis todoServis)
        {
            this.todoServis = todoServis;
        }


        public IActionResult List(string searchString)
        {
            var todo = todoServis.GetAllTodo();

            if (!String.IsNullOrEmpty(searchString))
            {
                todo = todoServis.FindingTodo(searchString);

            }
            //await todo.ToListAsync();
            return View(new TodoViewModel
            {
                Todo = todo
            });
        }

        [HttpPost]
        public string List(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        //public IActionResult List()
        //{
        //    var todo = todoServis.GetAllTodo();
        //    return View(new TodoViewModel
        //    {
        //        Todo = todo
        //    });
        //}
        public IActionResult Detail(long id)
        {
            var todo = todoServis.Detail(id);
            return View(todo);
        }

        public IActionResult NotDone()
        {
            var todo = todoServis.NotDone();
            return View(new TodoViewModel
            {
                Todo = todo
            });
        }

        public ActionResult Details(long id)
        {

            var todo = todoServis.FindTodo(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                todoServis.CreateTodo(todo);
                return RedirectToAction("List");
            }
            ViewBag.UserMessage = "Not valid data";
            return View();
        }

        [HttpGet]

        public ActionResult Delete(long id)
        {

            var todo = todoServis.FindTodo(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }


        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(long id)
        {
            todoServis.Delete(id);
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {

            var todo = todoServis.FindTodo(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }


        [HttpPost]

        public ActionResult Edit([Bind] Todo Todo)
        {
            if (ModelState.IsValid)
            {
                todoServis.EditTodo(Todo);
                return RedirectToAction("List");
            }
            return View(Todo);
        }
    }
}
