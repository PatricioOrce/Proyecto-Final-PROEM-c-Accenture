using Microsoft.EntityFrameworkCore;

namespace ProyectoProem.Models
{
    public class ProyectDB : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<Pagos> Pagos { get; set; }

        public ProyectDB(DbContextOptions<ProyectDB> options):base(options)
        {

        }
    }
}
