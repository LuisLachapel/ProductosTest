using Microsoft.EntityFrameworkCore;
namespace CrudProductos
{
    public class ContextManager: DbContext
    {
        public ContextManager(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<Productos>().HasKey(x => x.ProductoId);
        }

        public DbSet<Productos> Productos { get; set; }
    }
}
