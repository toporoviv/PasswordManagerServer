using Dapper;
using Domain;
using Domain.Entities.Records;
using Domain.Repositories.EmailPasswordManagerRepositories;
using Domain.Repositories.Postgres;
using Microsoft.Extensions.Options;

namespace DAL.Implementations.PasswordManagerRepositories;
public class EmailPasswordManagerRepository : PgRepository, IEmailPasswordManagerRepository
{
    public EmailPasswordManagerRepository(IOptions<PgOptions> pgOptions) : base(pgOptions.Value)
    {
    }

    public async Task Add(EmailPasswordManager entity, CancellationToken token)
    {
        const string sqlQuery = @"
insert into email_password_manager (email, password, date) 
values (@Email, @Password, @Date)";

        await using var connection = await GetConnection();
        await connection.ExecuteAsync(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Email = entity.Email,
                    Password = entity.Password,
                    Date = entity.Date
                },
                cancellationToken: token));
    }

    public async Task<IEnumerable<EmailPasswordManager>> GetAll(CancellationToken token)
    {
        const string sqlQuery = @"select id, email, password, date from email_password_manager";
        var cmd = new CommandDefinition(
           sqlQuery,
           commandTimeout: DefaultTimeoutInSeconds,
           cancellationToken: token);

        await using var connection = await GetConnection();
        return await connection.QueryAsync<EmailPasswordManager>(cmd);
    }

    public async Task<EmailPasswordManager?> GetByEmail(string email, CancellationToken token)
    {
        const string sqlQuery = @"select id, email, password, date from email_password_manager where email = @Email";
        var cmd = new CommandDefinition(
           sqlQuery,
           new
           {
               Email = email
           },
           commandTimeout: DefaultTimeoutInSeconds,
           cancellationToken: token);

        await using var connection = await GetConnection();
        return await connection.QueryFirstOrDefaultAsync<EmailPasswordManager>(cmd);
    }
}
