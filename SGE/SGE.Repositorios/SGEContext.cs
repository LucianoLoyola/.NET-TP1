using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios
{
    public class SGEContext : DbContext
    {
        public DbSet<UserAccount> UserAccount { get; set; }

        public SGEContext(DbContextOptions<SGEContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=UserAccount.sqlite");
            }
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder){

            // Configuración para convertir TipoPermiso a string
            modelBuilder.Entity<Permiso>()
                .Property(p => p.tipoPermiso)
                .HasConversion(
                    v => v.ToString(), // Convertir enumerativo a string
                    v => (TipoPermiso)Enum.Parse(typeof(TipoPermiso), v) // Convertir string a enumerativo
                );
            }
    }
}
