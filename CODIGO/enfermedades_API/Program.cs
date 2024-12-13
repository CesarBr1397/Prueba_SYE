using Microsoft.EntityFrameworkCore;
using MiMvcPostgres.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseStaticFiles();


app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EnfermedadCronica}/{action=Index}/{id?}");


app.Run();
