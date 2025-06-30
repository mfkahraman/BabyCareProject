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
                var settings = sp.GetRequiredService<IDatabaseSettings>();
                return new GenericRepository<Instructor>(db, settings.InstructorCollectionName);
            });

            services.AddScoped<IGenericRepository<Product>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                var settings = sp.GetRequiredService<IDatabaseSettings>();
                return new GenericRepository<Product>(db, settings.ProductCollectionName);
            });

            services.AddScoped<IGenericRepository<Banner>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                var settings = sp.GetRequiredService<IDatabaseSettings>();
                return new GenericRepository<Banner>(db, settings.BannerCollectionName);
            });

            services.AddScoped<IGenericRepository<About>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                var settings = sp.GetRequiredService<IDatabaseSettings>();
                return new GenericRepository<About>(db, settings.AboutCollectionName);
            });            
            
            services.AddScoped<IGenericRepository<OurService>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                var settings = sp.GetRequiredService<IDatabaseSettings>();
                return new GenericRepository<OurService>(db, settings.OurServiceCollectionName);
            });

            services.AddScoped<IGenericRepository<OurProgram>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                var settings = sp.GetRequiredService<IDatabaseSettings>();
                return new GenericRepository<OurProgram>(db, settings.OurProgramCollectionName);
            });

            return services;
        }

        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IOurServiceService, OurServiceService>();
            services.AddScoped<IOurProgramService, OurProgramService>();
            services.AddScoped<IImageService, ImageService>();

            return services;
        }

        public static IServiceCollection AddProjectValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            // Register all validators from the assembly containing the CreateBannerDtoValidator
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
