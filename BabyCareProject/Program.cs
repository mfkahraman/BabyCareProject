using BabyCareProject.Business.Abstract;
using BabyCareProject.Business.Concrete;
using BabyCareProject.Business.Mappings;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.DataAccess.Concrete;
using BabyCareProject.Entity.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// AutoMapper
builder.Services.AddAutoMapper(typeof(ProductMapping).Assembly);

// Database settings
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

#region Generic Repository Registrations

builder.Services.AddScoped<IGenericRepository<Instructor>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new GenericRepository<Instructor>(db, "Instructors");
});

builder.Services.AddScoped<IGenericRepository<Product>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new GenericRepository<Product>(db, "Products");
});

builder.Services.AddScoped<IGenericRepository<Banner>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new GenericRepository<Banner>(db, "Banners");
});

#endregion Generic Repository Registrations

#region Services

builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IImageService, ImageService>();

#endregion Services

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
