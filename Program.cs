using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TaskTrackerApp.Models;
using TaskTrackerApp.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Bind("DataBase", new Config());
builder.Services.AddDbContext<TrackerDbContext>(op => op.UseSqlServer(Config.ConnectionString));

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();
var supportedCultures = new[]
{
    new CultureInfo("ru"),
    new CultureInfo("en")
};
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ru"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
