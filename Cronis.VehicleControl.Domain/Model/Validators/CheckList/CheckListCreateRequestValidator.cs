using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using FluentValidation;

namespace Cronis.VehicleControl.Domain.Model.Validators
{
    public sealed class CheckListCreateRequestValidator : AbstractValidator<CheckListCreateRequest>
    {
        public CheckListCreateRequestValidator()
        {
            RuleFor(entity => entity.UserId)
                .NotNull().NotEqual(Guid.Empty)
                .WithMessage("UserId não preenchido.");
        }
    }
}
