using Npgsql;
using System.Transactions;

namespace Domain.Repositories.Postgres;
public abstract class PgRepository
{
    private readonly PgOptions _pgOptions;

    protected const int DefaultTimeoutInSeconds = 5;

    protected PgRepository(PgOptions pgOptions)
    {
        _pgOptions = pgOptions;
    }

    protected async Task<NpgsqlConnection> GetConnection()
    {
        if (Transaction.Current is not null &&
            Transaction.Current.TransactionInformation.Status is TransactionStatus.Aborted)
        {
            throw new TransactionAbortedException("Transaction was aborted (probably by user cancellation request)");
        }

        var connection = new NpgsqlConnection(_pgOptions.ConnectionString);
        await connection.OpenAsync();

        return connection;
    }
}
