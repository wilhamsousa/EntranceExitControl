using Gestran.VehicleControl.Domain.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestran.VehicleControl.Domain.Model.Entities
{
    public class ItemCheckList : BaseEntity
    {
        public ItemCheckList()
        {

        }

        public string Name { get; set; }
        public string Note { get; set; }

        public ItemCheckList(Guid id, string name, string note)
        {
            Id = id;
            Name = name;
            Note = note;

            Validate(this, new ItemCheckListValidator());
        }
    }
}
