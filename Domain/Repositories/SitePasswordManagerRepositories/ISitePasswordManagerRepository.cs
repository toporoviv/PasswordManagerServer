using Domain.Entities.Records;

namespace Domain.Repositories.SitePasswordManagerRepositories;
public interface ISitePasswordManagerRepository
{
    Task Add(SitePasswordManager entity, CancellationToken token);
    Task<IEnumerable<SitePasswordManager>> GetAll(CancellationToken token);
    Task<SitePasswordManager?> GetBySite(string site, CancellationToken token);
}
