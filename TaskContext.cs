using Microsoft.EntityFrameworkCore;
using ProyectoEF.Models;
using Task = ProyectoEF.Models.Task;

namespace ProyectoEF
{
    public class TaskContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) 
        {}
    }
}
