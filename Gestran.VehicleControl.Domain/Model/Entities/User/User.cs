﻿using Gestran.VehicleControl.Domain.Model.Base;

namespace Gestran.VehicleControl.Domain.Model.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            CheckLists = new HashSet<CheckList>();
        }

        public string Name { get; set; }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;

            Validate(this, new UserValidator());
        }

        public virtual ICollection<CheckList>? CheckLists { get; set; }
    }
}
