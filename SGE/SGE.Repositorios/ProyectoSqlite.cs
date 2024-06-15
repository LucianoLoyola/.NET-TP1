namespace SGE.Repositorios;
using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;
public class ProyectoSqlite{

    public static void Inicializar(){
        using var context=new UserAccountContext();
        if(context.Database.EnsureCreated()){
            Console.WriteLine("Se creó la base de datos");
        }
    }
}