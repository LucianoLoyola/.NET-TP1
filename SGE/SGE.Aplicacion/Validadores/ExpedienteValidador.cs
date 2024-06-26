﻿using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion;

public class ExpedienteValidador
{
    public bool Validar(Expediente expediente,int idUsuario, out string mensajeError){
        mensajeError = "";
        if(string.IsNullOrWhiteSpace(expediente.caratula)){
            mensajeError = "La caratula no puede estar vacia. \n";
        }
        if(idUsuario <= 0){
            mensajeError = "El id de usuario debe un entero mayor que 0";
        }
        return (mensajeError == "");
    } 
}
