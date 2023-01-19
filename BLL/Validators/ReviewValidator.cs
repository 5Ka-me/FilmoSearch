using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class ReviewValidator : AbstractValidator<ReviewModel>
    {
        public ReviewValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty();

            RuleFor(p => p.Description)
               .NotEmpty();

            RuleFor(p => p.Stars)
                .InclusiveBetween(0, 5).WithMessage("Incorrect rating");
        }
    }
}
