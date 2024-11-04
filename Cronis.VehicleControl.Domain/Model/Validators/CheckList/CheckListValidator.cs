using Cronis.VehicleControl.Domain.Model.Entities;
using FluentValidation;

namespace Cronis.VehicleControl.Domain.Model.Validators
{
    public class CheckListValidator : AbstractValidator<CheckList>
    {
        public CheckListValidator()
        {
            RuleFor(entity => entity.VehiclePlate)
                .NotEmpty().WithMessage("Placa não preenchida.")
                .Length(1, 20).WithMessage("Nome deve ter entre 1 e 20 caracteres.");

            RuleFor(entity => entity.UserId)
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .WithMessage("Usuário não preenchido.");
        }
    }
}
