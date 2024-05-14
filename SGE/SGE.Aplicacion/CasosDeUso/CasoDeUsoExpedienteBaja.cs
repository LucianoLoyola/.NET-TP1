namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion servicioAuth)
{
     public void Ejecutar(int idExpediente, int idUsuario,List<Tramite> listaT, CasoDeUsoTramiteBaja EliminarTramite, Permiso permiso){
        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar la baja");
        }
        else try{//realiza la eliminación
            repo.EliminarExpediente(idExpediente,listaT,EliminarTramite);
            //eliminar tambien los tramites
        }
        catch(RepositorioException repoException) {
            Console.WriteLine($"Operación cancelada - Objeto Inexistente\n{repoException.Message}");
        }
    }
}