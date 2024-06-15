using Microsoft.EntityFrameworkCore;
namespace SGE.Repositorios;
using SGE.Aplicacion;
public class UserAccountContext:DbContext{

    #nullable disable
    public DbSet<UserAccount> UserAccount {get;set;}
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("data source=UserAccount.sqlite");
    }
}