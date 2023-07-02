using Business.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.LoadMyServices();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=account}/{action=login}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=home}/{action=Index}/{id?}");
});

app.Run();
