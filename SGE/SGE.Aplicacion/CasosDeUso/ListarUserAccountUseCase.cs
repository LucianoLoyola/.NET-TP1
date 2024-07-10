namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class ListarUserAccountUseCase(IRepositorioUsuario repositorio):UserAccountUseCase(repositorio)
{
    public List<UserAccount>? Ejecutar()
    {
        try{
             List<UserAccount>? usuarios = Repositorio.GetUsuarios();
             return usuarios;
        }
        catch(Exception error){
            Console.WriteLine($"Error al obtener usuarios: {error.Message}");
            return null;
        }
    }
}