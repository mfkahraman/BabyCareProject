using BabyCareProject.Business.Abstract;
using BabyCareProject.Business.Concrete;
using BabyCareProject.Business.Mappings;
using BabyCareProject.Business.ValidationRules.Banner;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.DataAccess.Concrete;
using BabyCareProject.Entity.Entities;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BabyCareProject.WebUI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddSingleton<IMongoDatabase>(sp =>
            {
                var settings = sp.GetRequiredService<IDatabaseSettings>();
                var client = new MongoClient(settings.ConnectionString);
                return client.GetDatabase(settings.DatabaseName);
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Instructor>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                return new GenericRepository<Instructor>(db, "Instructors");
            });

            services.AddScoped<IGenericRepository<Product>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                return new GenericRepository<Product>(db, "Products");
            });

            services.AddScoped<IGenericRepository<Banner>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                return new GenericRepository<Banner>(db, "Banners");
            });

            return services;
        }

        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IImageService, ImageService>();

            return services;
        }

        public static IServiceCollection AddProjectValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CreateBannerDtoValidator>();

            return services;
        }

        public static IServiceCollection AddProjectAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductMapping).Assembly);
            return services;
        }
    }
}
