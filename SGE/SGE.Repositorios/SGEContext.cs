using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios
{
    public class SGEContext : DbContext
    {

        public DbSet<UserAccount> Usuarios { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Tramite> Tramites { get; set; }

        public DbSet<Permiso> Permisos{get; set;}

        // public SGEContext(DbContextOptions<SGEContext> options) : base(options)
        // {
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=SGE.sqlite");
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

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("Permisos"); 

                entity.Property(p => p.Id).IsRequired();
                entity.Property(p => p.tipoPermiso).IsRequired(); 

            });

            modelBuilder.Entity<Expediente>(entity =>
            {
                entity.ToTable("Expedientes");

                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.caratula).IsRequired();
                entity.Property(e => e.fechaHoraCreacion).IsRequired();
                entity.Property(e => e.fechaHoraUModificacion);
                entity.Property(e => e.IdUsuarioMod).IsRequired();
                entity.Property(e => e.estado).IsRequired();
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("Permiso");

                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.tipoPermiso).IsRequired();
            });

            modelBuilder.Entity<Tramite>(entity =>
            {
                entity.ToTable("Tramites");

                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.ExpedienteId).IsRequired();
                entity.Property(e => e.Etiqueta).IsRequired();
                entity.Property(e => e.Contenido);
                entity.Property(e => e.fechaHoraCreacion).IsRequired();
                entity.Property(e => e.fechaHoraUltimaModificacion);
                entity.Property(e => e.IdUsuarioMod).IsRequired();
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("user_account");

                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.UserName);
                entity.Property(e => e.Name).HasDefaultValue("no especificado");
                entity.Property(e => e.Surname).HasDefaultValue("no especificado");
                entity.Property(e => e.Email).HasDefaultValue("no especificado");
                entity.Property(e => e.Password);
                entity.Property(e => e.Role);
            });
         }
        

            
    }
}
