using System.Collections.Generic;

namespace TodoList.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
