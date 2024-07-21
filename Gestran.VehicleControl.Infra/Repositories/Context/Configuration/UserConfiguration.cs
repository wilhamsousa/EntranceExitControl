using Gestran.VehicleControl.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Repositories.Context.Configuration
{
    public class UserConfiguration : IEntityConfigurationStrategy
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Name)
                .HasDatabaseName(UserIndexes.Name)
                .IsUnique();
        }
    }

    public static class UserIndexes
    {
        public const string 
            Name = "IX_Name",
            Name2 = "";
    }
}
