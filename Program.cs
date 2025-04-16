
using InventarioWepExterna.DTO;
using InventarioWepExterna.Models;
using InventarioWepExterna.Server.Data;
using Microsoft.EntityFrameworkCore;
namespace InventarioWepExterna
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion"));
            });
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();
            app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
