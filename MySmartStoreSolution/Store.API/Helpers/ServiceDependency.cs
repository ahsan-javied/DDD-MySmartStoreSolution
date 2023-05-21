using Store.Application.Helper;
using Store.Application.Service;
using Store.Domain.Service;
using Store.Domain.UOW;
using Store.Infrastructure.UOW;

namespace Store.API.Helpers
{
    public static class ServiceDependency
    {
        public static void AddServicesDependencies(this IServiceCollection services)
        {
            //AddSingleton
            services.AddSingleton<IJWTManager, JWTManager>();

            //AddScoped

            //Unit of Work or repository is always transient as it does not then make cache issues.
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();

        }
    }
}
