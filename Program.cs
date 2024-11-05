
using Microsoft.EntityFrameworkCore;
using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Middlewares;
using Orders_Managment_System.Models;
using Orders_Managment_System.Repostiories;
using Orders_Managment_System.Services;

namespace Orders_Managment_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.
            builder.Services.AddScoped<IOrderRepositry, OrderRepositry>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IDerliveryRepo, DeliveryRepositry>();
            builder.Services.AddScoped<IDeliveryService, DeliveryService>();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.MaxDepth = 64;  
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<LimitRequestMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
