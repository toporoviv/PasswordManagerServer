using Domain.Entities.Records;

namespace Domain.Services.EmailPasswordManagerServices;
public interface IEmailPasswordManagerService
{
    Task AddEmail(EmailPasswordManager emailPasswordManager, CancellationToken token);
    Task<IEnumerable<EmailPasswordManager>> GetAll(CancellationToken token);
}
