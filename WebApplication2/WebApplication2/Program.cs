var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Show custom error page in production.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Enforces HTTPS redirection
app.UseStaticFiles(); // Allows static files like CSS, JS, Images, etc.

app.UseRouting(); // Enables routing
app.UseAuthorization(); // Enables authorization if needed

// Default route - changed from Home/Index to Account/Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"); // This will default to Account/Login if no controller is specified

// Custom route for AdminController


// Custom route for StudentManagementController
app.MapControllerRoute(
    name: "studentmanagement",
    pattern: "StudentManagement/{action=StudentManagement}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=AdminPage}/{menuItem?}");
app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{action=Dashboard}/{id?}");
// Run the application
app.Run();
