using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.BusinessLogic;
using ToDoApp.Interfaces;
using ToDoApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

ControllerStartup(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void ControllerStartup(WebApplicationBuilder? builder)
{
    builder.Services.AddDbContext<ToDoAppContext>(options =>
    {
        options.UseSqlServer("Server=DESKTOP-FBGOG4O\\TODOAPP;Database=ToDoApp;Trusted_Connection=True;TrustServerCertificate=True;");
    });
    builder.Services.AddScoped<ITaskManager, TaskManager>();
}