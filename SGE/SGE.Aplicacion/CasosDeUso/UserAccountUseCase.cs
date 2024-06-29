namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public abstract class UserAccountUseCase(IRepositorioUserAccount repositorio)
{
    protected IRepositorioUserAccount Repositorio { get; } = repositorio;
}