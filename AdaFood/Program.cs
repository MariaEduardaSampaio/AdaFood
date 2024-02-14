using AdaFood.Application.Filters;
using AdaFood.Application.Services;
using AdaFood.Domain;
using AdaFood.Domain.Interfaces;
using AdaFood.Repository;

namespace AdaFood
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();

            builder.Services.AddScoped<CustomAuthoritazionFilter>();
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });

            builder.Services.AddSingleton<IEntregadorRepository<Entregador>, EntregadorRepository>();
            builder.Services.AddSingleton<IEntregadorService, EntregadorService>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
