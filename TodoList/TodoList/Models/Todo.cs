using System;

namespace TodoList.Models
{
    public class Todo
    {
        // (Id: long, Title: string, IsUrgent: boolean(default false), IsDone: boolean(default false))
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsUrgent { get; set; } = false;
        public bool IsDone { get; set; } = false;

        public DateTime Inserted { get; set; }

        public Assignee Assignee { get; set; }
        public User User { get; set; }
        public int IdUser { get; set; }
    }
}
