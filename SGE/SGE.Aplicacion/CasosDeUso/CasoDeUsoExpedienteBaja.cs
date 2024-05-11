namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo)
{
     public void Ejecutar(int idExpediente, int idUsuario){
        //validacion de permiso de usuario
        repo.EliminarExpediente(idExpediente);
        //eliminar tambien los tramites
    }
}
