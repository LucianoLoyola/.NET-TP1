using Microsoft.EntityFrameworkCore;
namespace Repositorios;

public class UserAccountContext:DbContext{
    #nullable disable
    public DbSet<UserAccount> UserAccount {get;set;}
    #nullable restore

    protected override void OnCofiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.useSqlite("data source=UserAccount.sqlite");
    }
}