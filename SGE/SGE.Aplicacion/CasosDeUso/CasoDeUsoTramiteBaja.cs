namespace SGE.Aplicacion;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo)
{
     public void Ejecutar(int id){
        //validacion de permiso de usuario
        repo.EliminarTramite(id);
    }
}
