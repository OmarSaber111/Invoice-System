using DataLayer.InterFaces;
using DataLayer.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace DataLayer.DataLayerDI
{
    public static class DataLayerDI
    {
        public static IServiceCollection RegisterDataLayerDI(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IGovernmentRepository, GovernmentRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupRoleAuthRepository, GroupRoleAuthRepository>();
            services.AddScoped<IGroupUserRepository, GroupUserRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRequestRoleFormRepository, RequestRoleFormRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBlacklistRepository, BlacklistRepository>();


            return services;

        }
    }
}