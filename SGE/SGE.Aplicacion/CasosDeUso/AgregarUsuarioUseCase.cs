namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.ViewModels;

public class AgregarUsuarioUseCase(IRepositorioUsuario repositorio, UsuarioValidador validador, ServicioHash servicioHash):UserAccountUseCase(repositorio)
{
    public void Ejecutar(RegisterViewModel newUser, bool hayUsuarios)
    {
        if(!validador.Validar(newUser,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else try{
        // Crear una nueva cuenta de usuario
            var userAccount = new UserAccount
            {
                UserName = newUser.UserName,
                Password = servicioHash.GetHashSha256(newUser.Password),
                Role = hayUsuarios ? "Usuario" : "Administrador",
                Name = newUser.Name,
                Surname = newUser.Surname,
                Email = newUser.Email,
                Permisos = hayUsuarios
                    ? new List<Permiso>
                    {
                        new Permiso { tipoPermiso = TipoPermiso.Lectura } // Asignar permiso de lectura
                    }
                    : new List<Permiso>
                    {
                        new Permiso { tipoPermiso = TipoPermiso.Lectura }, // Asignar permiso de lectura
                        new Permiso { tipoPermiso = TipoPermiso.ExpedienteAlta },
                        new Permiso { tipoPermiso = TipoPermiso.ExpedienteModificacion },
                        new Permiso { tipoPermiso = TipoPermiso.ExpedienteBaja },
                        new Permiso { tipoPermiso = TipoPermiso.TramiteAlta },
                        new Permiso { tipoPermiso = TipoPermiso.TramiteModificacion },
                        new Permiso { tipoPermiso = TipoPermiso.TramiteBaja }
                    }
            };

            Repositorio.AgregarUsuario(userAccount);
        }
        catch(Exception error){
            Console.WriteLine($"Error al registrarse: {error.Message}");
        }
        
    }


    public void Ejecutar(UserAccount newUser, List<TipoPermiso> tipoPermisos)
    {
        if(!validador.Validar(newUser,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else try{
            if(newUser.Role is null){
                newUser.Role="Usuario";
            }
            newUser.Password=servicioHash.GetHashSha256(newUser.Password);
            AgregarPermisos(newUser,tipoPermisos);
        // Crear una nueva cuenta de usuario
            var userAccount = new UserAccount
            {
                UserName = newUser.UserName,
                Password = servicioHash.GetHashSha256(newUser.Password),
                Name = newUser.Name,
                Surname = newUser.Surname,
                Email = newUser.Email,
            };

            Repositorio.AgregarUsuario(userAccount);
        }
        catch(Exception error){
            Console.WriteLine($"Error al registrarse: {error.Message}");
        }
        
    }


    private void AgregarPermisos(UserAccount user, List<TipoPermiso> listaTipoPermisos){
        
        List<Permiso> permisosActuales = user.Permisos ?? new List<Permiso>();
        foreach(TipoPermiso tp in listaTipoPermisos){
            AgregarPermiso(tp,permisosActuales);
        }
        user.Permisos= permisosActuales;
    }

    //puede que no sea la solución mas eficiente
    private void AgregarPermiso(TipoPermiso tipoPermiso, List<Permiso> permisosActuales){
        
        switch (tipoPermiso)
        {
            case TipoPermiso.Lectura:
                permisosActuales.Add(new Permiso { tipoPermiso = TipoPermiso.Lectura } );
                break;
            case TipoPermiso.ExpedienteAlta:
                permisosActuales.Add(new Permiso { tipoPermiso = TipoPermiso.ExpedienteAlta } );
                break;
            case TipoPermiso.ExpedienteBaja:
                permisosActuales.Add(new Permiso { tipoPermiso = TipoPermiso.ExpedienteBaja } );
                break;
            case TipoPermiso.ExpedienteModificacion:
                permisosActuales.Add(new Permiso { tipoPermiso = TipoPermiso.ExpedienteModificacion } );
                break;
            case TipoPermiso.TramiteAlta:
                permisosActuales.Add(new Permiso { tipoPermiso = TipoPermiso.TramiteAlta } );
                break;
            case TipoPermiso.TramiteBaja:
                permisosActuales.Add(new Permiso { tipoPermiso = TipoPermiso.TramiteBaja } );
                break;
            case TipoPermiso.TramiteModificacion:
                permisosActuales.Add(new Permiso { tipoPermiso = TipoPermiso.TramiteModificacion } );
                break;
            default:
            break;
        }
        
    }


}