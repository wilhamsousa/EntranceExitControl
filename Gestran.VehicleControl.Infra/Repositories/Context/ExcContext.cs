using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Infra.Repositories.Context.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Repositories.Context
{
    public partial class ExcContext : DbContext
    {
        public ExcContext(DbContextOptions<ExcContext> options) : base(options)
        { 
        }

        public virtual DbSet<ItemCheckList> Item { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<CheckList> CheckList { get; set; }
        public virtual DbSet<CheckListItem> CheckListItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            MyModelConfigurationStrategy.Configure(builder, new UserConfiguration());
        }
    }
}
