using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class ActorValidator : AbstractValidator<ActorModel>
    {
        public ActorValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().Length(3, 20).WithMessage("{PropertyName} length error")
                .Matches("^[A-Z]{1}[a-z]*$").WithMessage("Incorrect first name");

            RuleFor(p => p.LastName)
               .NotEmpty().Length(3, 20).WithMessage("{PropertyName} length error")
               .Matches("^[A-Z]{1}[a-z]*$").WithMessage("Incorrect last name");
        }
    }
}
