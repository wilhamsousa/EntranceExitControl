using Cronis.VehicleControl.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cronis.VehicleControl.Infra.Repositories.Context.Configuration
{
    public class CheckListItemConfiguration : IEntityConfigurationStrategy
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<CheckListItem>()
                .HasOne(x => x.CheckListOption)
                .WithMany(x => x.CheckListItems)
                .HasForeignKey(x => x.CheckListOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
