using API.Middlewares;
using DAL.Extensions;
using DAL.Extensions.ServiceCollectionExtensions;
using Domain;
using FluentValidation.AspNetCore;
using Services.Extensions.ServiceCollectionExtensions;

namespace API;

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
        builder.Services.AddRepositories();
        builder.Services.AddServices();

        builder.Services.AddFluentValidation(conf =>
        {
            conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
            conf.AutomaticValidationEnabled = true;
        });

        builder.Services.Configure<PgOptions>(builder.Configuration.GetSection(nameof(PgOptions)));

        Postgres.AddMigrations(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseCors(options => options
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());

        app.UseAuthorization();

        app.MapControllers();

        app.MigrateUp();

        app.Run();
    }
}
