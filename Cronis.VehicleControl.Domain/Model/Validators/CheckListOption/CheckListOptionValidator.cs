using Cronis.VehicleControl.Domain.Model.Entities;
using FluentValidation;

namespace Cronis.VehicleControl.Domain.Model.Validators
{
    public class CheckListOptionValidator : AbstractValidator<CheckListOption>
    {
        public CheckListOptionValidator()
        {
            RuleFor(entity => entity.Name)
                .NotEmpty().WithMessage("Nome não preenchido.")
                .Length(1, 50).WithMessage("Nome deve ter entre 1 e 50 caracteres.");

            RuleFor(entity => entity.Note)
                .NotEmpty().WithMessage("Observação não preenchida.")
                .Length(1, 50).WithMessage("Observação deve ter entre 1 e 50 caracteres.");
        }
    }
}
