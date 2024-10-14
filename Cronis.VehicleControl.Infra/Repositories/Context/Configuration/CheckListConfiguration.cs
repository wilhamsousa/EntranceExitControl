using Cronis.VehicleControl.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cronis.VehicleControl.Infra.Repositories.Context.Configuration
{
    public class CheckListConfiguration : IEntityConfigurationStrategy
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<CheckList>()
                .HasIndex(u => new { u.VehiclePlate, u.StartDateTime })
                .IsUnique();

            builder.Entity<CheckList>()
                .HasMany(x => x.CheckListItems)
                .WithOne(x => x.CheckList)
                .HasForeignKey(x => x.CheckListId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<CheckList>()
                .HasOne(x => x.User)
                .WithMany(x => x.CheckLists)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
