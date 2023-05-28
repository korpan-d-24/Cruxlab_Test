using System.Text.RegularExpressions;
using Cruxlab_Test.Models;
using FluentValidation;

namespace Cruxlab_Test.Validators;

public class PasswordRequirementsModelValidator : AbstractValidator<PasswordRequirementsModel>
{
    public PasswordRequirementsModelValidator()
    {
        RuleFor(x => x.ObligatedSymbol).NotNull().NotEmpty();
        RuleFor(x => x.MinLetterCount).GreaterThan(0).LessThanOrEqualTo(x => x.MaxLetterCount);
        RuleFor(x => x.MaxLetterCount).GreaterThan(0);
        
        RuleFor(x => x.Password).NotNull().NotEmpty()
            .Matches(x =>  $@"^([^{x.ObligatedSymbol}]*{x.ObligatedSymbol}[^{x.ObligatedSymbol}]*){{{x.MinLetterCount},{x.MaxLetterCount}}}$", RegexOptions.Compiled)
            .WithMessage(x => $"The password must contain a minimum of {x.MinLetterCount} and a maximum of {x.MaxLetterCount} letter '{x.ObligatedSymbol}'.");
    }
}