using FluentValidation;

namespace Gestran.VehicleControl.Domain.Model.Entity.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(entity => entity.Name)
                .NotEmpty().WithMessage("Nome não preenchido.")
                .Length(1, 50).WithMessage("Nome deve ter entre 1 e 50 caracteres.");

            RuleFor(entity => entity.DuplicatedNameError)
                .Equal(false)
                .WithMessage("Registro com este nome já existe.");
        }
    }
}
