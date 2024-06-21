using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

namespace SGE.Repositorios
{
    public class UserAccountContext : DbContext
    {
        public DbSet<UserAccount> UserAccount { get; set; }

        public UserAccountContext(DbContextOptions<UserAccountContext> options) : base(options)
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
