namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class EliminarUserAccountUseCase(IRepositorioUsuario repositorio):UserAccountUseCase(repositorio)
{
    public void Ejecutar(int id)
    {
        Repositorio.EliminarUsuario(id);
    }
}