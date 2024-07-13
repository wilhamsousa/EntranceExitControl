using FluentValidation;

namespace Gestran.VehicleControl.Domain.Model.Entity.Validator
{
    public class CheckListValidator : AbstractValidator<CheckList>
    {
        public CheckListValidator()
        {
            RuleFor(entity => entity.VehiclePlate)
                .NotEmpty().WithMessage("Placa não preenchida.")
                .Length(1, 20).WithMessage("Nome deve ter entre 1 e 20 caracteres.");

            RuleFor(entity => entity.UserId)
                .NotEmpty().WithMessage("Usuário não preenchido.");

            RuleFor(entity => entity.DuplicatedPlateError)
                .Equal(false)
                .WithMessage($"Checklist pendente com esta placa já existe para outro usuário.");

            RuleFor(entity => entity.UserNotFoundError)
                .Equal(false)
                .WithMessage($"Usuário não encontrado.");
        }
    }
}
