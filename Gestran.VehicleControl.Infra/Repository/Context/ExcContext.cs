using Gestran.VehicleControl.Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Repository.Context
{
    public partial class ExcContext : DbContext
    {
        public ExcContext(DbContextOptions<ExcContext> options) : base(options)
        { 
        }

        public virtual DbSet<Item> Item { get; set; }
    }
}
