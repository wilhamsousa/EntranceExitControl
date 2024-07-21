﻿using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repositories.Context;
using Gestran.VehicleControl.Infra.Repositories.Context.Configuration;

namespace Gestran.VehicleControl.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ExcContext context) : base(context)
        {
        }

        public override Dictionary<string, string> MessageErrors()
        {
            return new Dictionary<string, string>
            {
                { UserIndexes.Name, "Este nome já existe." }
            };
        }
    }
}
