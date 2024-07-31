using FluentValidation;

namespace Gestran.VehicleControl.Domain.Model.DTOs.CheckList
{
    public class CheckListCreateDTOValidator : AbstractValidator<CheckListCreateDTO>
    {
        public CheckListCreateDTOValidator()
        {
            RuleFor(entity => entity.UserId)
                .NotNull().NotEqual(Guid.Empty)
                .WithMessage("UserId não preenchido.");
        }
    }
}
