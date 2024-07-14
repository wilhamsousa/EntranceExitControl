using Gestran.VehicleControl.Domain.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestran.VehicleControl.Domain.Model.Entity
{
    public class ItemCheckList : BaseEntity
    {
        public ItemCheckList()
        {

        }

        public string Name { get; set; }
        public string Note { get; set; }

        [NotMapped]
        public bool DuplicatedNameError { get; private set; }

        public void SetDuplicated()
        {
            DuplicatedNameError = true;
            Validate(this, new ItemCheckListValidator());
        }

        public ItemCheckList(Guid id, string name, string note)
        {
            Id = id;
            Name = name;
            Note = note;

            Validate(this, new ItemCheckListValidator());
        }
    }
}
