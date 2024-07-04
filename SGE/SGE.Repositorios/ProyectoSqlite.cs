using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
namespace SGE.Repositorios;

public class SGESqlite
{
    public static void Inicializar(DbContextOptions<SGEContext> options)
    {
        using var context = new SGEContext(options);
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó la base de datos");
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }

    }
}
