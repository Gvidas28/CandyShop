using CandyShop.Model.Repositories;
using CandyShop.Model.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            RegisterServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var form = serviceProvider.GetRequiredService<LoginPage>();
            Application.Run(form);
        }

        static void RegisterServices(ServiceCollection services)
        {
            services.AddScoped<LoginPage>();
            services.AddScoped<AdminPage>();
            services.AddScoped<RegisterPage>();
            services.AddScoped<CustomerPage>();
            services.AddScoped<ItemDetailsPage>();
            services.AddScoped<QuantityPage>();
            services.AddScoped<CommentsPage>();
            services.AddScoped<AddCommentPage>();
            services.AddScoped<AdminAddPage>();
            services.AddScoped<AdminUpdatePage>();
            services.AddScoped<CustomerAddPage>();
            services.AddScoped<CustomerUpdatePage>();
            services.AddScoped<EmployeeAddPage>();
            services.AddScoped<EmployeeUpdatePage>();
            services.AddScoped<ItemAddPage>();
            services.AddScoped<ItemUpdatePage>();
            services.AddScoped<OrderAddPage>();
            services.AddScoped<OrderUpdatePage>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}