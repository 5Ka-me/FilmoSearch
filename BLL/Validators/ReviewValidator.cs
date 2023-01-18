using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class ReviewValidator : AbstractValidator<ReviewModel>
    {
        public ReviewValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().Length(3, 20).WithMessage("{PropertyName} length error")
                .Matches("^[a-zA-Z]*$").WithMessage("Incorrect first name");

            RuleFor(p => p.Description)
               .NotEmpty().Length(5, 200).WithMessage("{PropertyName} length error")
               .Matches("^[a-zA-Z]*$").WithMessage("Incorrect last name");

            RuleFor(p => p.Stars)
                .InclusiveBetween(0, 5).WithMessage("Incorrect rating");
        }
    }
}
