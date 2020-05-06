using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoList.Db;
using TodoList.Models;

namespace TodoList.Services
{
    public class UserService : IUserService
    {
        private readonly TodoListDbContext todoListDb;

        public UserService(TodoListDbContext todoListDb)
        {
            this.todoListDb = todoListDb;
        }

        public void AddNewTaskToUser(Todo todo)
        {

            todoListDb.Todos.Add(todo);
            todoListDb.SaveChanges();
        }

        public void CreateUser(User user)
        {
            todoListDb.Add(user);
            todoListDb.SaveChanges();
        }

        public User DetailUser(int id)
        {
            return todoListDb.Users.Include(t => t.Todos).FirstOrDefault(u => u.Id == id);

        }

        public IEnumerable<User> GetUser()
        {
            return todoListDb.Users.Include(t => t.Todos);
        }
    }
}
