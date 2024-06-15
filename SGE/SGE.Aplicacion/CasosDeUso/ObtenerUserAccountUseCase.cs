
namespace SGE.Aplicacion;

public class ObtenerUserAccountUseCase(IRepositorioUserAccount repositorio):UserAccountUseCase(repositorio)
{
    public UserAccount? Ejecutar(int id)
    {
    //aquí podríamos insertar código de validación de cliente

        return Repositorio.GetCliente(id);
    }
}