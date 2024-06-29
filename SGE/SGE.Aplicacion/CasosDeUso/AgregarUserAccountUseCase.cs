

namespace SGE.Aplicacion;

public class AgregarUserAccountUseCase(IRepositorioUserAccount repositorio):UserAccountUseCase(repositorio)
{
    public void Ejecutar(UserAccount userAccount)
    {
    //aquí podríamos insertar código de validación de cliente

        Repositorio.AgregarUserAccount(userAccount);
    }
}