using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Services
{
    public interface ITodoServis
    {
        IEnumerable<Todo> GetAllTodo();
        IEnumerable<Todo> NotDone();
        IEnumerable<Todo> Done();
        IEnumerable<Todo> OnlyUrgent();

        Todo FindTodo(long id);
        Todo Detail(long id);

        void CreateTodo(Todo todo);


        void Delete(long id);
        void EditTodo(Todo todo);
        IEnumerable<Todo> FindingTodo(string searchString);
    }
}
