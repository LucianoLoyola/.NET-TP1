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
    }
}
