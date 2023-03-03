using finalProject.Business.Services.Abstracts.Categories;
using finalProject.Business.Services.Abstracts.Products;
using finalProject.Business.Services.Abstracts.Users;
using finalProject.Business.Services.Concretes.Categories;
using finalProject.Business.Services.Concretes.Products;
using finalProject.Business.Services.Concretes.Users;
using finalProject.DataAccess.Repositories.Abstracts.Categories;
using finalProject.DataAccess.Repositories.Abstracts.Products;
using finalProject.DataAccess.Repositories.Abstracts.Users;
using finalProject.DataAccess.Repositories.Concretes.Categories;
using finalProject.DataAccess.Repositories.Concretes.Products;
using finalProject.DataAccess.Repositories.Concretes.Users;
using Microsoft.Extensions.DependencyInjection;

namespace finalProject.Business.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            #region Scopes
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryTypeRepository, CategoryTypeRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryTypeService, CategoryTypeService>();
            services.AddScoped<IUserService, UserService>();
            #endregion

            return services;
        }
    }
}
