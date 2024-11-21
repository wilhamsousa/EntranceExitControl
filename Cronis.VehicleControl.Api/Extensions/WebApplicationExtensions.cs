using Cronis.VehicleControl.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Cronis.VehicleControl.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void ApplyMigration(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _Db = scope.ServiceProvider.GetRequiredService<ExcContext>();
                if (_Db != null)
                {
                    if (_Db.Database.GetPendingMigrations().Any())
                    {
                        _Db.Database.Migrate();
                    }
                }
            }
        }
    }
}
