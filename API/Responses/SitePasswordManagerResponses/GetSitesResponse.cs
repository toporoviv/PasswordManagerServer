using Domain.Entities.Records;

namespace API.Responses.SitePasswordManagerResponses;

public class GetSitesResponse
{
    public required SitePasswordManager[] SitePasswordManagers { get; init; }
}
