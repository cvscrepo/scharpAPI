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

        //Cuando se sobreescribe un método no se le puede cambiar su modificador de acceso
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category() { Id = Guid.Parse("a18f9882-1dd3-4ed7-bfed-b491aed7ba25"), Name = "Actividades pendientes", Peso = 20 });
            categories.Add(new Category() { Id = Guid.Parse("a18f9882-1dd3-4ed7-bfed-b491aed7ba02"), Name = "Actividades Personales", Peso = 50 });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(c => c.Id);
                category.Property(p => p.Name).IsRequired().HasMaxLength(100);
                category.Property(p => p.Description);
                category.Property(p => p.Peso);

                category.HasData(categories);
            });


            List<Task> tasks = new List<Task>();
            tasks.Add(new Task() { Id = Guid.Parse("b007a8c9-6d59-4557-9e9c-7a7082f23e1e"), CategoryId = Guid.Parse("a18f9882-1dd3-4ed7-bfed-b491aed7ba25"), PriorityTask = Priority.Medium, Title = "Pagos de servicios publicos", CreatedDate = DateTime.Now });
            tasks.Add(new Task() { Id = Guid.Parse("b007a8c9-6d59-4557-9e9c-7a7082f24e1e"), CategoryId = Guid.Parse("a18f9882-1dd3-4ed7-bfed-b491aed7ba02"), PriorityTask = Priority.Low, Title = "Terminar de ver peliculas en Netflix", CreatedDate = DateTime.Now });


            modelBuilder.Entity<Task>(task =>
            {
                task.ToTable("Task");
                task.HasKey(task => task.Id);
                task.HasOne(p=> p.Category).WithMany(p=> p.Tasks).HasForeignKey(p=>p.CategoryId);
                task.Property(p=> p.Title).IsRequired().HasMaxLength(200);
                task.Property(p=> p.Description);
                task.Property(p => p.PriorityTask);
                task.Property(p => p.CreatedDate);
                task.Property(p => p.DateOfCompletion);
                task.Ignore(p => p.Summary);


                task.HasData(tasks);
            });
        }

        
    }
}
 