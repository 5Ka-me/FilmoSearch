using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class FilmValidator : AbstractValidator<FilmModel>
    {
        public FilmValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty();
        }
    }
}
