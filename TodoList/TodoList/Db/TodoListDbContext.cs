using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Db
{
    public class TodoListDbContext : IdentityDbContext<Assignee>
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public DbSet<User> Users { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Todo>()
                .Property(t => t.Inserted)
                .HasDefaultValueSql("getdate()");
        }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword

        public DbSet<TodoList.ViewModel.AssigneeListViewModel> AssigneeListViewModel { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword

        public DbSet<TodoList.ViewModel.AssigneeViewModel> AssigneeViewModel { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword

        public DbSet<TodoList.ViewModel.EditAssigneeViewModel> EditAssigneeViewModel { get; set; }
    }
}
