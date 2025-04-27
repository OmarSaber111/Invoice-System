using BusinessLayer.Services;
using BussinesLayer.Interfaces.Token;
using BussinessLayer.InterFaces;
using BussinessLayer.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.BussinessLayerDI
{
    public static class BussinessLayerDI
    {
        public static IServiceCollection RegisterBussinessLayerDi(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(AdminService).Assembly);


            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBuyerService, BuyerService>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IGovernmentService, GovernmentService>();
            services.AddScoped<IGroupService, GroupService>();
            //services.AddScoped<IGroupRoleAuthService, GroupRoleAuthService>();
            //services.AddScoped<IGroupUserService, GroupUserService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IRequestService, RequestService>();
            //services.AddScoped<IRequestRoleFormService, RequestRoleFormService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
