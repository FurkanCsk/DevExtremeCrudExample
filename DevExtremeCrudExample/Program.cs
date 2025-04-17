using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.Helpers;
using DevExtremeCrudExample.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dapper Repository'lerini Dependency Injection'a ekle
builder.Services.AddScoped<StudentRepository>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    return new StudentRepository(config.GetConnectionString("Default"));
});

builder.Services.AddScoped<CourseRepository>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    return new CourseRepository(config.GetConnectionString("Default"));
});

// DevExtreme için JSON serializer uyumu
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Varsayýlan route tanýmý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Students}/{id?}");

app.Run();