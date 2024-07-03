using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
namespace SGE.Repositorios

{
    public static class ProyectoSqlite
    {
        public static void Inicializar(DbContextOptions<SGEContext> options)
        {
            using var context = new SGEContext(options);
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
