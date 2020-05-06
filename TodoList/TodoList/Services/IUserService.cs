using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUser();
        User DetailUser(int id);
        void CreateUser(User user);
        void AddNewTaskToUser(Todo todo);
    }
}
