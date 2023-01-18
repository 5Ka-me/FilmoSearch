﻿using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class FilmValidator : AbstractValidator<FilmModel>
    {
        public FilmValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().Length(3, 20).WithMessage("{PropertyName} length error")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Incorrect title");
        }
    }
}
