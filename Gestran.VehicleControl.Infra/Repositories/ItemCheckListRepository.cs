﻿using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repositories.Context;

namespace Gestran.VehicleControl.Infra.Repositories
{
    public class ItemCheckListRepository : BaseRepository<ItemCheckList>, IItemCheckListRepository
    {
        public ItemCheckListRepository(ExcContext context, NotificationContext notificationContext) : base(context, notificationContext)
        {
        }
    }
}
