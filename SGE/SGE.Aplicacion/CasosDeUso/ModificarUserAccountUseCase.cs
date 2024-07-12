namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;

public class ModificarUserAccountUseCase(IRepositorioUsuario repositorio, UsuarioValidador validador, IServicioHash servicioHash):UserAccountUseCase(repositorio)
{
    public void Ejecutar(UserAccount userAccount, string newPassword)
    {
        if(!validador.Validar(userAccount.UserName,newPassword,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else{
            userAccount.Password = servicioHash.GetHashSha256(newPassword);
            Repositorio.ModificarUsuario(userAccount);
        }
    }

    public void Ejecutar(UserAccount updated,List<TipoPermiso> tipoPermisos)
    {
        if(!validador.ValidarModif(updated,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else{
            if(updated.Role is null){
                updated.Role="Usuario";
            }
            Repositorio.ModificarUsuario(updated,tipoPermisos);
        }
    }


    public void Ejecutar(UserAccount updated)
    {
        if(!validador.ValidarModif(updated,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else{

            Repositorio.ModificarUsuario(updated);
        }
    }


}