using SGE.Aplicacion.Interfaces;

namespace AL.Aplicacion.UseCases;

public abstract class ExpedienteUseCase
{
   protected IRepositorioExpediente Repositorio { get; private set; }

   public ExpedienteUseCase(IRepositorioExpediente repositorio)
   {
       this.Repositorio = repositorio;
   }
}
