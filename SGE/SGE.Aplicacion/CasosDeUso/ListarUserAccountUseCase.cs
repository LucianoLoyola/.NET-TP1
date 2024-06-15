using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace UseCases;

public class ListarUserAccountUseCase(IRepositorioUserAccount repositorio):UserAccountUseCase(repositorio)
{
    public List<UserAccount> Ejecutar()
    {
    //aquí podríamos insertar código de validación de cliente

        return Repositorio.ListarUserAccount();
    }
}