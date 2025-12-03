
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<INoteRepository, NoteRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Notes}/{action=Index}/{id?}");

app.Run();