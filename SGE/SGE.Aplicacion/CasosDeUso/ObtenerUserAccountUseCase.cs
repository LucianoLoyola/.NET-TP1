using System.Reflection.Metadata.Ecma335;

namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class ObtenerUserAccountUseCase(IRepositorioUsuario repositorio):UserAccountUseCase(repositorio)
{
    //obtener usuario por id
    public UserAccount? Ejecutar(int id)
    {
        try{
             UserAccount? user=Repositorio.GetUsuario(id);
             return user;
        }
        catch(Exception){
            //Console.WriteLine($"Error al obtener usuario: {error.Message}");
            return null;
        }
        
    }

    //obtener usuario por username
    public UserAccount? Ejecutar(string userName)
    {
        try{
             UserAccount? user=Repositorio.GetUsuario(userName);
             return user;
        }
        catch(RepositorioException e){
            
            //Console.WriteLine($"Error al obtener usuario: {error.Message}");
            return null;
        }
        catch(Exception e){
            
            //Console.WriteLine($"Error al obtener usuario: {error.Message}");
            return null;
        }
    }
}