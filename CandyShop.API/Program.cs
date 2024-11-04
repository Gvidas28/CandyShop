using CandyShop.Model.Repositories;
using CandyShop.Model.Services;

namespace CandyShop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            RegisterServices(builder.Services);

            var app = builder.Build();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IAdminRepository, AdminRepository>();
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
        }
    }
}