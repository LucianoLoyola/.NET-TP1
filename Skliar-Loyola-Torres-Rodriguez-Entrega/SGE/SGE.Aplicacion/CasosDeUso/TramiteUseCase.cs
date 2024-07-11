using SGE.Aplicacion.Interfaces;

namespace AL.Aplicacion.UseCases;

public abstract class TramiteUseCase
{
   protected IRepositorioTramite Repositorio { get; private set; }

   public TramiteUseCase(IRepositorioTramite repositorio)
   {
       this.Repositorio = repositorio;
   }
}