using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class BlogValidator : AbstractValidator<Blog>
{
    public BlogValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Title).MaximumLength(150);
        RuleFor(x => x.Title).MinimumLength(5);
        RuleFor(x => x.Content).NotEmpty();
        RuleFor(x => x.Content).MinimumLength(5);
        RuleFor(x => x.Image).NotEmpty();
        RuleFor(x => x.ThumbnailImage).NotEmpty();
    }
}