using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x=>x.CategoryName).NotEmpty();
        RuleFor(x=>x.CategoryName).MinimumLength(3);
        RuleFor(x=>x.CategoryName).MaximumLength(50);
        RuleFor(x=>x.Description).NotEmpty();
        
    }
}