namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class ObtenerUserAccountUseCase(IRepositorioUsuario repositorio):UserAccountUseCase(repositorio)
{
    public UserAccount? Ejecutar(int id)
    {
    //aquí podríamos insertar código de validación de cliente
        UserAccount? user=Repositorio.GetUsuario(id);
        if (user == null){//si no se encontró expediente, excepción
            throw new RepositorioException($"No se encontró un usuario con el ID {id}");
        }
        else{
            return user;
        }
        
    }

        public UserAccount? Ejecutar(string userName)
    {
    //aquí podríamos insertar código de validación de cliente
        UserAccount? user=Repositorio.GetUsuario(userName);
        if (user == null){//si no se encontró expediente, excepción
            throw new RepositorioException($"No se encontró un usuario con el Username {userName}");
        }
        else{
            return user;
        }
        
    }
}