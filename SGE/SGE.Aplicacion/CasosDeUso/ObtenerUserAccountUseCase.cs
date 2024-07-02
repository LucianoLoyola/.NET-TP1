namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class ObtenerUserAccountUseCase(IRepositorioUsuario repositorio):UserAccountUseCase(repositorio)
{
    public UserAccount? Ejecutar(int id)
    {
    //aquí podríamos insertar código de validación de cliente

        return Repositorio.GetUsuario(id);
    }
}