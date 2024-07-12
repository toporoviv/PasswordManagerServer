using Domain.Entities.Records;
using Domain.Exceptions.SitePasswordManagerExceptions;
using Domain.Repositories.SitePasswordManagerRepositories;
using Domain.Services.SitePasswordManagerServices;

namespace Services.Implementations.SitePasswordManagerServices;
public class SitePasswordManagerServices
    (ISitePasswordManagerRepository sitePasswordManagerRepository): ISitePasswordManagerService
{
    public async Task AddSite(SitePasswordManager sitePasswordManager, CancellationToken token)
    {
        var sitePasswordManagerFromDb = await sitePasswordManagerRepository
            .GetBySite(sitePasswordManager.Site, token);

        if (sitePasswordManagerFromDb is not null)
        {
            throw new SiteExistsException($"Сайт {sitePasswordManagerFromDb.Site} уже существует");
        }

        await sitePasswordManagerRepository.Add(sitePasswordManager, token);
    }

    public async Task<IEnumerable<SitePasswordManager>> GetAllSites(CancellationToken token)
    {
        return await sitePasswordManagerRepository.GetAll(token);
    }
}
