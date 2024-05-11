namespace SGE.Aplicacion;

public class TramiteValidador
{
    public bool Validar(Tramite tramite,int idUsuario, out string mensajeError){
        mensajeError = "";
        if(string.IsNullOrWhiteSpace(tramite.Contenido)){
            mensajeError = "El contenido del trámite no puede estar vacio. \n";
        }
        if(idUsuario <= 0){
            mensajeError = "El id de usuario debe un entero mayor que 0";
        }
        return (mensajeError == "");
    } 
}
