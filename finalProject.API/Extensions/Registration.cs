using finalProject.Common.Repositories.MongoDb.Settings;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

namespace finalProject.API.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.Configure<MongoDbSettings>(config.GetSection("MongoDb"));
            services.AddScoped<IMongoDbSettings, MongoDbSettings>(i =>
            {
                return i.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            });

            return services;
        }
    }
}
