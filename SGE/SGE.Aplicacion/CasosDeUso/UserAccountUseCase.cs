
namespace SGE.Aplicacion;

public abstract class UserAccountUseCase(IRepositorioUserAccount repositorio)
{
    protected IRepositorioUserAccount Repositorio { get; } = repositorio;
}