using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEF;
using System.Formats.Tar;
using Task = ProyectoEF.Models.Task;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TaskContext>(otp => otp.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("cnTask"));

//Connection whit windows security
//"Data Source=(local); Initial Catalog= TareasDb;Trusted_Connection=True; Integrated Security=True"

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServicesAttribute] TaskContext dbContext) =>
{
        dbContext.Database.EnsureCreated();
        return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TaskContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(p => p.Category));
});

app.MapPost("/api/tareas", async ([FromServices] TaskContext dbContext, [FromBody] Task task) =>
{
    try
    {
        task.Id = Guid.NewGuid();
        task.CreatedDate = DateTime.Now;
        await dbContext.AddAsync(task);

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    catch(Exception ex)
    {
        return Results.Ok(ex.Message);
    }
    
});
app.MapPut("/api/tareas/{id}", async ([FromServices] TaskContext dbContext, [FromBody] Task task, [FromRoute] Guid id) =>
{
    try
    {
        var currentTask = dbContext.Tasks.Find(id);


        if (currentTask != null)
        {
            currentTask.CategoryId = task.CategoryId;
            currentTask.Title = task.Title;
            currentTask.PriorityTask = task.PriorityTask;
            currentTask.Description = task.Description;
            await dbContext.SaveChangesAsync();
            return Results.Ok("Ok");
        }
        return Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Ok(ex.Message);
    }

});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TaskContext dbContext, [FromBody] Task task, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);

    if(currentTask != null)
    {
        dbContext.Remove(currentTask);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound(id);
});
app.Run();
