namespace SGE.Aplicacion;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo)
{
     public void Ejecutar(int idTramite, int idUsuario){
        //validacion de permiso de usuario
        repo.EliminarTramite(idTramite);
    }
}
