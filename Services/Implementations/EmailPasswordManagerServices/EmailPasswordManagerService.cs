using Domain.Entities.Records;
using Domain.Exceptions.EmailPasswordManagerExceptions;
using Domain.Repositories.EmailPasswordManagerRepositories;
using Domain.Services.EmailPasswordManagerServices;

namespace Services.Implementations.EmailPasswordManagerServices;
public class EmailPasswordManagerService
    (IEmailPasswordManagerRepository emailPasswordManagerRepository) : IEmailPasswordManagerService
{
    public async Task AddEmail(EmailPasswordManager emailPasswordManager, CancellationToken token)
    {
        var emailPasswordManagerFromDb = await emailPasswordManagerRepository
            .GetByEmail(emailPasswordManager.Email, token);

        if (emailPasswordManagerFromDb is not null)
        {
            throw new EmailExistsException($"Email {emailPasswordManagerFromDb.Email} уже существует");
        }

        await emailPasswordManagerRepository.Add(emailPasswordManager, token);
    }

    public async Task<IEnumerable<EmailPasswordManager>> GetAll(CancellationToken token)
    {
        return await emailPasswordManagerRepository.GetAll(token);
    }
}
