using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class WriterValidator : AbstractValidator<Writer>
{
    public WriterValidator()
    {
        RuleFor(x => x.FullName).NotEmpty();
        RuleFor(x => x.FullName).MinimumLength(2);
        RuleFor(x => x.FullName).MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty();
        // RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Password).Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").WithMessage("Password must contain at least 8 characters, At least one uppercase letter, At least one lowercase letter, At least one number and At least one special character.");
    }
}