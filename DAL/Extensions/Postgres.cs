using Microsoft.Extensions.DependencyInjection;
using Npgsql.NameTranslation;
using Npgsql;
using FluentMigrator.Runner;
using Domain;
using Microsoft.Extensions.Options;
using DAL.Migrations;
using System.Reflection;

namespace DAL.Extensions;
public static class Postgres
{
    private static readonly INpgsqlNameTranslator Translator = new NpgsqlSnakeCaseNameTranslator();

    public static void AddMigrations(IServiceCollection services)
    {
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb.AddPostgres()
                .WithGlobalConnectionString(s =>
                {
                    var cfg = s.GetRequiredService<IOptions<PgOptions>>();
                    return cfg.Value.ConnectionString;
                })
                .ScanIn(typeof(InitSchema).Assembly).For.All()
            )
            .AddLogging(lb => lb.AddFluentMigratorConsole());
    }
}