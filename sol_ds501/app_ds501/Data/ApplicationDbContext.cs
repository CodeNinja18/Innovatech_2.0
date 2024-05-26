using app_ds501.Models;
using Microsoft.EntityFrameworkCore;

namespace app_ds501.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Personal> Personal { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<Metodo> Metodo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
