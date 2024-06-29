namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion servicioAuth)
{
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
}