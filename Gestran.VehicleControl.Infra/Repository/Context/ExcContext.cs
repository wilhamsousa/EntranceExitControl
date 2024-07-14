using Gestran.VehicleControl.Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Repository.Context
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
    }
}
