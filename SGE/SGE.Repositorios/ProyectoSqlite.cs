using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;

namespace SGE.Repositorios
{
    public static class ProyectoSqlite
    {
        public static void Inicializar(DbContextOptions<UserAccountContext> options)
        {
            using var context = new UserAccountContext(options);
            if (context.Database.EnsureCreated())
            {
                Console.WriteLine("Se creó la base de datos");
                context.UserAccount.Add(new UserAccount(){UserName="user", Password="Password", Role="User"});
                context.UserAccount.Add(new UserAccount(){UserName="admin",Password="Password",Role="Administrator"});
                context.SaveChanges();
            }
        }
    }
}
