using Cronis.VehicleControl.Domain.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cronis.VehicleControl.Domain.Model.Entities
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

    public static class ItemCheckListMessage
    {
        public const string
            ITEMCHECKLIST_ALREADY_EXISTS = "Já existe um item de checklist com este nome.";
    }
}
