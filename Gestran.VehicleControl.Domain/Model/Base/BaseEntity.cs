using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using System.Text.Json.Serialization;

namespace Gestran.VehicleControl.Domain.Model.Base
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public Guid Id { get; protected set; }

        [NotMapped]
        public bool Valid { get; protected set; }

        [NotMapped]
        public bool Invalid => !Valid;

        public void SetId(Guid id) => Id = id;
        public Guid Identifier { get => Id; }



        [NotMapped, JsonIgnore]
        public FluentValidation.Results.ValidationResult? ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }

    }
}
