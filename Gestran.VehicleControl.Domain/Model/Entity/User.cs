using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Entity.Validator;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestran.VehicleControl.Domain.Model.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        [NotMapped]
        public bool DuplicatedNameError { get; private set; }

        public void SetDuplicated()
        {
            DuplicatedNameError = true;
            Validate(this, new UserValidator());
        }

        public User()
        {

        }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;

            Validate(this, new UserValidator());
        }
    }
}
