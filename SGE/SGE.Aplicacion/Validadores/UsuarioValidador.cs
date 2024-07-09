using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion;

public class UsuarioValidador
{
    public bool Validar(UserAccount user, out string mensajeError){
        mensajeError = "";
        if(string.IsNullOrWhiteSpace(user.UserName)){
            mensajeError = mensajeError+"El nombre de usuario no puede estar vacio. \n";
        }
        if(string.IsNullOrWhiteSpace(user.Name)){
            mensajeError = mensajeError+"El nombre no puede estar vacio. \n";
        }
        if(string.IsNullOrWhiteSpace(user.Surname)){
            mensajeError = mensajeError+"El apellido no puede estar vacio. \n";
        }
        if(string.IsNullOrWhiteSpace(user.Role)){
            mensajeError = mensajeError+"El rol no puede estar vacío. \n";
        }
        if(string.IsNullOrWhiteSpace(user.Email)){
            mensajeError = mensajeError+"El email no puede estar vacío. \n";
        }
        if(string.IsNullOrWhiteSpace(user.Password)){
            mensajeError = mensajeError+"La contraseña no puede estar vacía. \n";
        }
        
        return (mensajeError == "");
    } 
}
