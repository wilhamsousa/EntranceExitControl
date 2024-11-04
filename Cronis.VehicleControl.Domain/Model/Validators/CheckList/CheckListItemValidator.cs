using Cronis.VehicleControl.Domain.Model.Entities;
using FluentValidation;

namespace Cronis.VehicleControl.Domain.Model.Validators
{
    public class CheckListItemValidator : AbstractValidator<CheckListItem>
    {
        public CheckListItemValidator()
        {
        }
    }
}
