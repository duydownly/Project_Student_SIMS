using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Data;

var builder = WebApplication.CreateBuilder(args);

// Ensure the connection string for SIMSDB is correctly set up
builder.Services.AddDbContext<WebApplication2Context>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WebApplication2Context")
        ?? throw new InvalidOperationException("Connection string 'WebApplication2Context' not found.")));

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Define routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{action=Dashboard}/{id?}");

app.MapControllerRoute(
    name: "studentmanagement",
    pattern: "StudentManagement/{action=StudentManagement}/{id?}");

app.MapControllerRoute(
    name: "teachermanagement",
    pattern: "TeacherManagement/{action=TeacherManagement}/{id?}");

app.MapControllerRoute(
    name: "coursemanagement",
    pattern: "CourseManagement/{action=CourseManagement}/{id?}");

app.MapControllerRoute(
    name: "enrollmanagement",
    pattern: "EnrollManagement/{action=EnrollManagement}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=StudentView}/{action=Index}/{studentId?}");


app.MapControllerRoute(
    name: "defaultAdmin",
    pattern: "{controller=Admin}/{action=AdminPage}/{menuItem?}");

// Run the application
app.Run();
