using Microsoft.EntityFrameworkCore;

namespace Cronis.VehicleControl.Infra.Repositories.Context.Configuration
{
    public interface IEntityConfigurationStrategy
    {
        void Configure(ModelBuilder builder);
    }
}
