namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public abstract class UserAccountUseCase(IRepositorioUsuario repositorio)
{
    protected IRepositorioUsuario Repositorio { get; } = repositorio;
}