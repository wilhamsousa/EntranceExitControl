using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Entity.Validator;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestran.VehicleControl.Domain.Model.Entity
{
    public class Item : BaseEntity
    {
        public Item()
        {
            
        }

        public string Name { get; set; }
        public string Note { get; set; }

        [NotMapped]
        public bool DuplicatedNameError { get; private set; }

        public void SetDuplicated()
        {
            DuplicatedNameError = true;
            Validate(this, new ItemValidator());
        }

        public Item(Guid id, string name, string note)
        {
            Id = id;
            Name = name;
            Note = note;

            Validate(this, new ItemValidator());
        }
    }
}
