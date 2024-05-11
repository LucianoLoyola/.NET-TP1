namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo)
{
     public void Ejecutar(int id){
        //validacion de permiso de usuario
        repo.EliminarExpediente(id);
        //eliminar tambien los tramites
    }
}
