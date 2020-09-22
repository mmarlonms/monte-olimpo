using FluentValidation;
using MonteOlimpo.Domain.Models;

namespace MonteOlimpo.Domain.Validator
{
    public class GodValidator : AbstractValidator<God>
    {
        public GodValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Nome).Length(0, 10);
            RuleFor(x => x.Idade).InclusiveBetween(18, 60);
            RuleFor(x => x.Idade).InclusiveBetween(20, 30);
        }
    }
}