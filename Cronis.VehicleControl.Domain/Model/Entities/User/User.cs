﻿using Cronis.VehicleControl.Domain.Model.Base;
using Cronis.VehicleControl.Domain.Model.Validators;
using System.Text.Json.Serialization;

namespace Cronis.VehicleControl.Domain.Model.Entities
{
    public class User : BaseEntity
    {        
        public string Name { get; set; }

        public User()
        {
            CheckLists = new HashSet<CheckList>();
        }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;

            Validate(this, new UserValidator());
        }

        [JsonIgnore]
        public virtual ICollection<CheckList>? CheckLists { get; set; }
    }

    public static class UserMessage
    {
        public const string
            USERNAME_ALREADY_EXISTS = "Já existe um usuário com este nome.";
    }
}
