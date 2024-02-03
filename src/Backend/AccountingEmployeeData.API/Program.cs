
using AccountingEmployeeData.Application;
using AccountingEmployeeData.Data;
using AccountingEmployeeData.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AccountingEmployeeData.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
            builder.Services.AddScoped<EmployeeRepository>();
            builder.Services.AddScoped<EmployeeService>();
            builder.Services.AddControllers();
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

            app.UseAuthorization();
            app.UseMiddleware<ExceptionMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}