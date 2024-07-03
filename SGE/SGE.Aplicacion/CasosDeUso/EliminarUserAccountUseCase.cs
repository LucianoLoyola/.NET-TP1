namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class EliminarUsuarioUseCase(IRepositorioUsuario repositorio):UserAccountUseCase(repositorio)
{
    public void Ejecutar(int id)
    {
    //aquí podríamos insertar código de validación de cliente

        Repositorio.EliminarUsuario(id);
    }
}