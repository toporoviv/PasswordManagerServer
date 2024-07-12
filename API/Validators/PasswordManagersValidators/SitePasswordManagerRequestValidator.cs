using API.Requests.PasswordManagerRequests;
using FluentValidation;

namespace Backend.Validators.PasswordManagersValidators;

public class SitePasswordManagerRequestValidator : AbstractValidator<SitePasswordManagerRequest>
{
    public SitePasswordManagerRequestValidator()
    {
        RuleFor(x => x.Password)
            .NotNull()
            .MinimumLength(8);

        RuleFor(x => x.Site)
            .NotNull()
            .NotEmpty();
    }
}
