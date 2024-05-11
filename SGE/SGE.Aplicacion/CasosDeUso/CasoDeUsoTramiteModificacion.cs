namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo)
{
    public void Ejecutar(Tramite tramite, int idUsuario){
        //validacion del permiso de usuario
        tramite.fechaHoraUltimaModificacion = DateTime.Now;
        repo.ModificarTramite(tramite);
    }
}
