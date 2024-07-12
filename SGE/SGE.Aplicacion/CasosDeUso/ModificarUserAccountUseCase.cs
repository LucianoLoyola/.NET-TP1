namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;

public class ModificarUserAccountUseCase(IRepositorioUsuario repositorio, UsuarioValidador validador, IServicioHash servicioHash):UserAccountUseCase(repositorio)
{
    public void Ejecutar(UserAccount userAccount, string newPassword)
    {
        userAccount.Password = servicioHash.GetHashSha256(newPassword);
        if(!validador.Validar(userAccount,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else{
            Repositorio.ModificarUsuario(userAccount);
        }
    }

    public void Ejecutar(UserAccount updated,List<TipoPermiso> tipoPermisos)
    {
        if(!validador.Validar(updated,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else{
            var userAccount = new UserAccount
            {
                UserName = updated.UserName,
                Name = updated.Name,
                Surname = updated.Surname,
                Email = updated.Email,
            };
            AgregarPermisos(userAccount,tipoPermisos);
            Repositorio.ModificarUsuario(userAccount);
        }
    }


    public void Ejecutar(UserAccount updated)
    {
        if(!validador.Validar(updated,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else{
            var userAccount = new UserAccount
            {
                UserName = updated.UserName,
                Name = updated.Name,
                Surname = updated.Surname,
                Email = updated.Email,
            };

            Repositorio.ModificarUsuario(userAccount);
        }
    }

    private void AgregarPermisos(UserAccount user, List<TipoPermiso> listaTipoPermisos){
        
        List<Permiso> nuevosPermisos = new List<Permiso>();
        foreach(TipoPermiso tp in listaTipoPermisos){
            AgregarPermiso(tp,nuevosPermisos);
        }
        user.Permisos= nuevosPermisos;
    }

    //puede que no sea la solución mas eficiente
    private void AgregarPermiso(TipoPermiso tipoPermiso, List<Permiso> nuevosPermisos){
        
        switch (tipoPermiso)
        {
            case TipoPermiso.Lectura:
                nuevosPermisos.Add(new Permiso { tipoPermiso = TipoPermiso.Lectura } );
                break;
            case TipoPermiso.ExpedienteAlta:
                nuevosPermisos.Add(new Permiso { tipoPermiso = TipoPermiso.ExpedienteAlta } );
                break;
            case TipoPermiso.ExpedienteBaja:
                nuevosPermisos.Add(new Permiso { tipoPermiso = TipoPermiso.ExpedienteBaja } );
                break;
            case TipoPermiso.ExpedienteModificacion:
                nuevosPermisos.Add(new Permiso { tipoPermiso = TipoPermiso.ExpedienteModificacion } );
                break;
            case TipoPermiso.TramiteAlta:
                nuevosPermisos.Add(new Permiso { tipoPermiso = TipoPermiso.TramiteAlta } );
                break;
            case TipoPermiso.TramiteBaja:
                nuevosPermisos.Add(new Permiso { tipoPermiso = TipoPermiso.TramiteBaja } );
                break;
            case TipoPermiso.TramiteModificacion:
                nuevosPermisos.Add(new Permiso { tipoPermiso = TipoPermiso.TramiteModificacion } );
                break;
            default:
            break;
        }
        
    }



}