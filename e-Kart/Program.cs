using e_Kart.Core;
using e_Kart.Core.Mapper;
using e_Kart.Infrastructure;
using FluentValidation.AspNetCore;
namespace e_Kart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add services
            builder.Services.AddInfrastructureServices();
            builder.Services.AddCoreServices();
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(ApplicationUserMapper).Assembly);
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http:localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            var app = builder.Build();
            app.UseExceptionHandlingMiddleware();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
