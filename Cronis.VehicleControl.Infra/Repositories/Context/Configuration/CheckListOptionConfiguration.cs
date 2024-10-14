using Cronis.VehicleControl.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cronis.VehicleControl.Infra.Repositories.Context.Configuration
{
    public class CheckListOptionConfiguration : IEntityConfigurationStrategy
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<CheckListOption>()
                .HasMany(x => x.CheckListItems)
                .WithOne(x => x.CheckListOption)
                .HasForeignKey(x => x.CheckListOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
