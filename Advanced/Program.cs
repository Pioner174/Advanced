using Advanced.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:PeopleConnection"]);
    opts.EnableSensitiveDataLogging(true);
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("controllers", "controllers/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

SeedData.SeedDatabase(context);

app.Run();

