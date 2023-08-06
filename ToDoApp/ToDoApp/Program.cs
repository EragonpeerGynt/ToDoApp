using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ToDoApp.BusinessLogic;
using ToDoApp.Interfaces;
using ToDoApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

ControllerRegistration(builder);
SwaggerRegistration(builder);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
SwaggerStartup(app);
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ControllerRegistration(WebApplicationBuilder builder)
{
    string sqlServer = builder.Configuration.GetSection("ConnectionStrings:SqlServer").Get<string>();
    builder.Services.AddDbContext<ToDoAppContext>(options =>
    {
        options.UseSqlServer(sqlServer);
    });
    builder.Services.AddScoped<ITaskManager, TaskManager>();
}

static void SwaggerRegistration(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerDocument();
}

static void SwaggerStartup(WebApplication app)
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}