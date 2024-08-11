using Cronis.VehicleControl.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cronis.VehicleControl.Infra.Repositories.Context.Configuration
{
    public class UserConfiguration : IEntityConfigurationStrategy
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
