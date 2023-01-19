using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class ActorValidator : AbstractValidator<ActorModel>
    {
        public ActorValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty();

            RuleFor(p => p.LastName)
               .NotEmpty();
        }
    }
}
