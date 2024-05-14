﻿namespace SGE.Aplicacion;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoT, IExpedienteRepositorio repoE, IServicioAutorizacion servicioAuth, IServicioActualizacionEstado servicioUpdate){
    public void Ejecutar(int idTramite, Expediente expediente, int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso)){//verifica la autorizacion del usuario
            throw new AutorizacionException("El usuario no tiene permiso para realizar la baja");
        }
        else {//realiza el borrado
                repoT.EliminarTramite(idTramite);
                expediente.EliminarTramiteDeLista(expediente, idTramite);
                servicioUpdate.actualizarEstadoExpediente(expediente.Id,repoE,expediente.listaTramites);
       }
    }
    //método sobrecargado para las veces que se realiza el borrado de expediente, y no es necesario actualizar el estado del mismo
    public void Ejecutar(int idTramite, int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso)){//verifica la autorizacion del usuario
            throw new AutorizacionException("El usuario no tiene permiso para realizar la baja");
        }
        else {//realiza el borrado
                repoT.EliminarTramite(idTramite);
        }
    }


}