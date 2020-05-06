using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.ViewModel
{
    public class TodoViewModel
    {
        public IEnumerable<Todo> Todo { get; internal set; }
    }
}
