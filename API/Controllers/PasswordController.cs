using API.Requests.PasswordManagerRequests;
using API.Responses.EmailPasswordManagerResponses;
using API.Responses.SitePasswordManagerResponses;
using Domain.Entities.Records;
using Domain.Services.EmailPasswordManagerServices;
using Domain.Services.SitePasswordManagerServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class PasswordController
    (IEmailPasswordManagerService emailPasswordManagerService,
    ISitePasswordManagerService sitePasswordManagerService) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<GetEmailsResponse> GetEmails()
    {
        var data = await emailPasswordManagerService.GetAll(default);

        return new GetEmailsResponse
        {
            EmailPasswordManagers = data.ToArray()
        };
    }

    [HttpGet("[action]")]
    public async Task<GetSitesResponse> GetSites()
    {
        var data = await sitePasswordManagerService.GetAllSites(default);

        return new GetSitesResponse
        {
            SitePasswordManagers = data.ToArray()
        };
    }

    [HttpPost("[action]")]
    public async Task AddNewEmail(EmailPasswordManagerRequest request)
    {
        await emailPasswordManagerService.AddEmail(new EmailPasswordManager
        {
            Email = request.Email,
            Date = DateTime.Now,
            Password = request.Password
        }, default);
    }

    [HttpPost("[action]")]
    public async Task AddNewSite(SitePasswordManagerRequest request)
    {
        await sitePasswordManagerService.AddSite(new SitePasswordManager
        {
            Site = request.Site,
            Date = DateTime.Now,
            Password = request.Password
        }, default);
    }
}
