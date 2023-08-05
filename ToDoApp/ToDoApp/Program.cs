using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ToDoApp.BusinessLogic;
using ToDoApp.Interfaces;
using ToDoApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

ControllerStartup(builder);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ControllerStartup(WebApplicationBuilder? builder)
{
    builder.Services.AddDbContext<ToDoAppContext>(options =>
    {
        options.UseSqlServer("Server=DESKTOP-FBGOG4O\\TODOAPP;Database=ToDoApp;Trusted_Connection=True;TrustServerCertificate=True;");
    });
    builder.Services.AddScoped<ITaskManager, TaskManager>();
}