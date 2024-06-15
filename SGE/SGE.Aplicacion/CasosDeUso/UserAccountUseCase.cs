using SGE.Aplicacion.Interfaces;

namespace CasosDeUso;

public abstract class UserAccountUseCase(IRepositorioUserAccount repositorio)
{
    protected IRepositorioUserAccount Repositorio { get; } = repositorio;
}