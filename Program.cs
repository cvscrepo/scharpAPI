using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskContext>(otp => otp.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServicesAttribute] TaskContext dbContext) =>
    {
        dbContext.Database.EnsureCreated();
        return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();