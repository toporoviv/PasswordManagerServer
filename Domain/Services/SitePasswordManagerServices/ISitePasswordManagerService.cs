using Domain.Entities.Records;

namespace Domain.Services.SitePasswordManagerServices;
public interface ISitePasswordManagerService
{
    Task AddSite(SitePasswordManager sitePasswordManager, CancellationToken token);
    Task<IEnumerable<SitePasswordManager>> GetAllSites(CancellationToken token);
}
