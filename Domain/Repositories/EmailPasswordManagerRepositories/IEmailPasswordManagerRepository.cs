using Domain.Entities.Records;

namespace Domain.Repositories.EmailPasswordManagerRepositories;
public interface IEmailPasswordManagerRepository
{
    Task Add(EmailPasswordManager entity, CancellationToken token);
    Task<IEnumerable<EmailPasswordManager>> GetAll(CancellationToken token);
    Task<EmailPasswordManager?> GetByEmail(string email, CancellationToken token);
}
