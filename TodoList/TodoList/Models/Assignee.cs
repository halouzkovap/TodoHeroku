using Microsoft.AspNetCore.Identity;

namespace TodoList.Models
{
    public class Assignee : IdentityUser
    {
        public string Name { get; set; }
    }
}
