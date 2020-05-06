using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.ViewModel
{
    public class UserViewModel
    {
        public IEnumerable<User> User { get; set; }
    }
}