using Gestran.VehicleControl.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Repositories.Context.Configuration
{
    public class CheckListConfiguration : IEntityConfigurationStrategy
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<CheckList>()
                .HasIndex(u => new { u.VehiclePlate, u.StartDateTime })
                .HasDatabaseName(CheckListIndexes.VehiclePlateStartDateTime)
                .IsUnique();

            builder.Entity<CheckList>()
                .HasOne(x => x.User)
                .WithMany(x => x.CheckLists)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName(CheckListIndexes.CheckListUser);
        }
    }

    public static class CheckListIndexes
    {
        public const string
            VehiclePlateStartDateTime = "IX_VehiclePlateStartDateTime",
            CheckListUser = "FK_CheckList_User";
    }
}
