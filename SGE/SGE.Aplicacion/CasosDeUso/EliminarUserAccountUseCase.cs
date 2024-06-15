using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace UseCases;

public class EliminarUserAccountUseCase(IRepositorioUserAccount repositorio):UserAccountUseCase(repositorio)
{
    public void Ejecutar(int id)
    {
    //aquí podríamos insertar código de validación de cliente

        Repositorio.EliminarUserAccount(id);
    }
}