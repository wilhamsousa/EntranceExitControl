using FluentValidation;

namespace Gestran.VehicleControl.Domain.Model.Entity.Validator
{
    public class CheckListValidator : AbstractValidator<CheckList>
    {
        public CheckListValidator()
        {
            RuleFor(entity => entity.VehiclePlate)
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(20);
            RuleFor(entity => entity.DuplicatedPlateError)
                .Equal(false)
                .WithMessage($"Checklist pendente com esta placa já existe para outro usuário.");
        }
    }
}
