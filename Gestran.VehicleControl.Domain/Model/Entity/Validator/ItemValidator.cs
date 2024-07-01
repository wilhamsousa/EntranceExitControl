using FluentValidation;

namespace Gestran.VehicleControl.Domain.Model.Entity.Validator
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(entity => entity.Name)
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(50);
            RuleFor(entity => entity.Note)
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(50);
            RuleFor(entity => entity.DuplicatedNameError)
                .Equal(false)
                .WithMessage("Registro com este nome já existe.");
        }
    }
}
