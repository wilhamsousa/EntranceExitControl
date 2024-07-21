using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Repositories.Context.Configuration
{
    public interface IEntityConfigurationStrategy
    {
        void Configure(ModelBuilder builder);
    }
}
