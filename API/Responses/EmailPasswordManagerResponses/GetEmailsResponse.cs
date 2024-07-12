using Domain.Entities.Records;

namespace API.Responses.EmailPasswordManagerResponses;

public class GetEmailsResponse
{
    public required EmailPasswordManager[] EmailPasswordManagers { get; init; }
}
