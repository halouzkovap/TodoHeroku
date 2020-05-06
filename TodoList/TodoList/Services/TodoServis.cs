using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoList.Db;
using TodoList.Models;

namespace TodoList.Services
{
    public class TodoServis : ITodoServis
    {
        private readonly TodoListDbContext listDbContext;

        public TodoServis(TodoListDbContext listDbContext)
        {
            this.listDbContext = listDbContext;
        }



        public IEnumerable<Todo> GetAllTodo()
        {
            return listDbContext.Todos.Include(u => u.User);
        }

        public IEnumerable<Todo> NotDone()
        {
            return listDbContext.Todos.Where(td => td.IsDone == false);

        }

        public IEnumerable<Todo> OnlyUrgent()
        {
            return listDbContext.Todos.Where(td => td.IsUrgent == true);

        }

        public IEnumerable<Todo> Done()
        {
            return listDbContext.Todos.Where(td => td.IsDone == true);
        }

        public Todo FindTodo(long id)
        {
            return listDbContext.Todos.Find(id);
        }

        public void CreateTodo(Todo todo)
        {
            listDbContext.Add(todo);
            listDbContext.SaveChanges();
        }

        public void Edit(long id)
        {
            listDbContext.SaveChanges();

        }

        public void Delete(long id)
        {
            var toto = listDbContext.Todos.Find(id);
            listDbContext.Todos.Remove(toto);

            listDbContext.SaveChanges();

        }

        public void EditTodo(Todo todo)
        {
            listDbContext.Entry(todo).State = EntityState.Modified;
            listDbContext.SaveChanges();
        }

        public Todo Detail(long id)
        {
            return listDbContext.Todos.Include(u => u.User).FirstOrDefault(t => t.Id == id);

        }

        public IEnumerable<Todo> FindingTodo(string searchString)
        {
            throw new System.NotImplementedException();
        }
    }
}
