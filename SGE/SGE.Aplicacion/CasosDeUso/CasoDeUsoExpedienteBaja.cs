namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo)
{
     public void Ejecutar(int idExpediente, int idUsuario,List<Tramite> listaT, CasoDeUsoTramiteBaja EliminarTramite){
        //validacion de permiso de usuario
        repo.EliminarExpediente(idExpediente,listaT,EliminarTramite);
        //eliminar tambien los tramites
    }
}
