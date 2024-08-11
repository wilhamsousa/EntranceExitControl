using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cronis.VehicleControl.Domain.Model.Base
{
    public abstract record BaseRecord
    {
        [NotMapped, JsonIgnore]
        public bool Valid { get; protected set; }

        [NotMapped, JsonIgnore]
        public bool Invalid { get => !Valid; }


        [NotMapped, JsonIgnore]
        public FluentValidation.Results.ValidationResult? ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }

    }
}
