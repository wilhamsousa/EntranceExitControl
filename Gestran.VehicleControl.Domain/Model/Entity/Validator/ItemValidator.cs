using FluentValidation;

namespace Gestran.VehicleControl.Domain.Model.Entity.Validator
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(entity => entity.Name)
                .NotEmpty().WithMessage("Nome não preenchido.")
                .Length(1, 50).WithMessage("Nome deve ter entre 1 e 50 caracteres.");

            RuleFor(entity => entity.Note)
                .NotEmpty().WithMessage("Observação não preenchida.")
                .Length(1, 50).WithMessage("Observação deve ter entre 1 e 50 caracteres.");

            RuleFor(entity => entity.DuplicatedNameError)
                .Equal(false)
                .WithMessage("Registro com este nome já existe.");
        }
    }
}
