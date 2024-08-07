﻿namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoExpedienteBaja(IRepositorioExpediente repo, IServicioAutorizacion servicioAuth)
{


    //este metodo queda en desuso, puesto que la propiedad DELETE ON CASCADE de la propiedad de navegación nos facilita el trabajo
     public void Ejecutar(int idExpediente, int idUsuario, TipoPermiso permiso){
        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("No tiene permiso para realizar la baja");
        }
        else try{//realiza la eliminación
            repo.EliminarExpediente(idExpediente);
        }
        catch(RepositorioException repoException) {
            Console.WriteLine($"Operación cancelada - Objeto Inexistente\n{repoException.Message}");
        }
    }
}