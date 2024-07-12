using Dapper;
using Domain;
using Domain.Entities.Records;
using Domain.Repositories.Postgres;
using Domain.Repositories.SitePasswordManagerRepositories;
using Microsoft.Extensions.Options;

namespace DAL.Implementations.PasswordManagerRepositories;
public class SitePasswordManagerRepository : PgRepository, ISitePasswordManagerRepository
{
    public SitePasswordManagerRepository(IOptions<PgOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task Add(SitePasswordManager entity, CancellationToken token)
    {
        const string sqlQuery = @"
insert into site_password_manager (site, password, date) 
values (@Site, @Password, @Date)";

        await using var connection = await GetConnection();
        await connection.ExecuteAsync(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Site = entity.Site,
                    Password = entity.Password,
                    Date = entity.Date
                },
                cancellationToken: token));
    }

    public async Task<IEnumerable<SitePasswordManager>> GetAll(CancellationToken token)
    {
        const string sqlQuery = @"select id, site, password, date from site_password_manager";
        var cmd = new CommandDefinition(
           sqlQuery,
           commandTimeout: DefaultTimeoutInSeconds,
           cancellationToken: token);

        await using var connection = await GetConnection();
        return await connection.QueryAsync<SitePasswordManager>(cmd);
    }

    public async Task<SitePasswordManager?> GetBySite(string site, CancellationToken token)
    {
        const string sqlQuery = @"select id, site, password, date from site_password_manager where site = @Site";
        var cmd = new CommandDefinition(
           sqlQuery,
           new
           {
               Site = site
           },
           commandTimeout: DefaultTimeoutInSeconds,
           cancellationToken: token);

        await using var connection = await GetConnection();
        return await connection.QueryFirstOrDefaultAsync<SitePasswordManager>(cmd);
    }
}
