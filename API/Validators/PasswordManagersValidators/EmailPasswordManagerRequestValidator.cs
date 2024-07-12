using API.Requests.PasswordManagerRequests;
using FluentValidation;

namespace API.Validators.PasswordManagersValidators;

public class EmailPasswordManagerRequestValidator : AbstractValidator<EmailPasswordManagerRequest>
{
    public EmailPasswordManagerRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotNull()
            .MinimumLength(8);
    }
}
