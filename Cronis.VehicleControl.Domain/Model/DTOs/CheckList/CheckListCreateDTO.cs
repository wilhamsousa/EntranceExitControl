using FluentValidation.Results;
using Cronis.VehicleControl.Domain.Model.Base;

namespace Cronis.VehicleControl.Domain.Model.DTOs.CheckList
{
    public record CheckListCreateDTO : BaseRecord
    {
        public Guid UserId { get; set; }
        public string VehiclePlate { get; set; }

        public ValidationResult Validate()
        {
            Validate(this, new CheckListCreateDTOValidator());
            return ValidationResult;
        }
    }
}
