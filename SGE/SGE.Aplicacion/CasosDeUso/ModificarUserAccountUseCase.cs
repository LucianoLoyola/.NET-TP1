namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class ModificarUserAccountUseCase(IRepositorioUserAccount repositorio):UserAccountUseCase(repositorio)
{
    public void Ejecutar(UserAccount userAccount)
    {
    //aquí podríamos insertar código de validación de cliente

        Repositorio.ModificarUserAccount(userAccount);
    }
}