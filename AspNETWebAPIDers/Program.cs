using AspNETWebAPIDers.Models;
using LMS.Data.Entities;
using LMS.Data.Repositories;
using LMS.Data.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace AspNETWebAPIDers
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
            // CORS POLICY

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", build =>
                {
                    build.AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
                });
            });

            //Database Connection
            builder.Services.AddDbContext<LMSDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
            });

            // SERVÝCES
            builder.Services.AddScoped(typeof(ResponseModel));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUserRepository, UserRepository>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("AllowAll");
            app.Run();
        }
    }
}