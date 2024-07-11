using SGE.Aplicacion.Entidades;
using System.Text;
using SGE.Aplicacion.Interfaces;


namespace SGE.Aplicacion;

public class UsuarioValidador
{
    public bool Validar(UserAccount user, out string mensajeError)
    {
        var errores = new StringBuilder();

        if (string.IsNullOrWhiteSpace(user.UserName))
            errores.AppendLine("El nombre de usuario no puede estar vacío.");
        
        if (string.IsNullOrWhiteSpace(user.Name))
            errores.AppendLine("El nombre no puede estar vacío.");
        
        if (string.IsNullOrWhiteSpace(user.Surname))
            errores.AppendLine("El apellido no puede estar vacío.");
        
        if (string.IsNullOrWhiteSpace(user.Role))
            errores.AppendLine("El rol no puede estar vacío.");
        
        if (string.IsNullOrWhiteSpace(user.Email))
            errores.AppendLine("El email no puede estar vacío.");
        
        if (string.IsNullOrWhiteSpace(user.Password))
            errores.AppendLine("La contraseña no puede estar vacía.");

        mensajeError = errores.ToString();
        return string.IsNullOrEmpty(mensajeError);
    }

}
