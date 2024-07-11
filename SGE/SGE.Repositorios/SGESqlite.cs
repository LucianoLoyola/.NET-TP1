using Microsoft.EntityFrameworkCore;
namespace SGE.Repositorios;

public class SGESqlite
{
    public static void Inicializar(DbContextOptions<SGEContext> options)
    {
        using var context = new SGEContext(options);
        //context.Database.EnsureDeleted(); //HABILITAR ESTA LINEA PARA BORRAR BD
        context.Database.EnsureCreated();
        if (context.Database.EnsureCreated())
        {
            //Agregar acá sentencias para inicilizar la base de datos con contenido - también se utiliza CODE FIRST
            //context.Usuarios.Add(new UserAccount() { UserName = "Test",Email="test@gmail.com" });
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
