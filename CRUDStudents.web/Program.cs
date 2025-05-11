using CRUDStudents.web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//injecting the Application Db Context using depentence enjection  ( after injecting we shold be able to use it inside our controllers views )
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentPortal"))); //waiting for connection string from the application.json files 
/*
1.builder.Services.AddDbContext<ApplicationDbContext>():
•	This registers your ApplicationDbContext class with the dependency injection container.
•	ApplicationDbContext is typically a class that inherits from DbContext (part of Entity Framework Core) and represents your database context. It contains DbSet properties for interacting with your database tables.
2.	options => options.UseSqlServer(...):
•	This configures the DbContext to use SQL Server as the database provider.
•	UseSqlServer is an extension method provided by the Microsoft.EntityFrameworkCore.SqlServer package, which must be installed in your project.
3.	builder.Configuration.GetConnectionString("StudentPortal"):
•	This retrieves the connection string named "StudentPortal" from your appsettings.json file (or other configuration sources).
•	The connection string typically contains information like the database server address, database name, and authentication details.
*/


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
