namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoExpedienteBaja(IRepositorioExpediente repo, IServicioAutorizacion servicioAuth)
{


    //este metodo queda en desuso, puesto que la propiedad DELETE ON CASCADE de la propiedad de navegación nos facilita el trabajo
     public void Ejecutar(int idExpediente, int idUsuario,List<Tramite> listaT, CasoDeUsoTramiteBaja EliminarTramite, Permiso permiso){
        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar la baja");
        }
        else try{//realiza la eliminación
            repo.EliminarExpediente(idExpediente,listaT,EliminarTramite);
        }
        catch(RepositorioException repoException) {
            Console.WriteLine($"Operación cancelada - Objeto Inexistente\n{repoException.Message}");
        }
    }

    public void Ejecutar(int idExpediente, Permiso permiso){
        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario (deberia usar el contexto para obtener el usuario)
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar la baja");
        }
        else try{//realiza la eliminación
            repo.EliminarExpediente(idExpediente,listaT,EliminarTramite);
        }
        catch(RepositorioException repoException) {
            Console.WriteLine($"Operación cancelada - Objeto Inexistente\n{repoException.Message}");
        }
    }
}