using FluentValidation;

namespace Cronis.VehicleControl.Domain.Model.Entities
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(entity => entity.Name)
                .NotEmpty().WithMessage("Nome não preenchido.")
                .Length(1, 50).WithMessage("Nome deve ter entre 1 e 50 caracteres.");
        }
    }
}
