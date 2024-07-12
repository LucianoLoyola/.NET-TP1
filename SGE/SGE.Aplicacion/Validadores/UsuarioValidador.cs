using SGE.Aplicacion.Entidades;
using System.Text;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.ViewModels;


namespace SGE.Aplicacion;

public class UsuarioValidador
{
    public bool Validar(UserAccount user, out string mensajeError)
    {
        var errores = new StringBuilder();

        if (string.IsNullOrWhiteSpace(user.UserName))
            errores.AppendLine("El nombre de usuario no puede estar vacío.\n");
        else if (user.UserName.Length > 20)
        errores.AppendLine("El nombre de usuario no puede exceder los 20 caracteres.");
        
        if (string.IsNullOrWhiteSpace(user.Name))
            errores.AppendLine("El nombre no puede estar vacío.");
        
        if (string.IsNullOrWhiteSpace(user.Surname))
            errores.AppendLine("El apellido no puede estar vacío.");
        
        if (string.IsNullOrWhiteSpace(user.Email))
            errores.AppendLine("El email no puede estar vacío.");
        
        if (string.IsNullOrWhiteSpace(user.Password))
            errores.AppendLine("La contraseña no puede estar vacía.\n");
        else if (user.Password.Length > 20)
        errores.AppendLine("La contraseña no puede exceder los 20 caracteres.");

        mensajeError = errores.ToString();
        return string.IsNullOrEmpty(mensajeError);
    }

    public bool Validar(RegisterViewModel user, out string mensajeError)
    {
        var errores = new StringBuilder();

        if (string.IsNullOrWhiteSpace(user.UserName))
            errores.AppendLine("El nombre de usuario no puede estar vacío.\n");
        else if (user.UserName.Length > 20)
        errores.AppendLine("El nombre de usuario no puede exceder los 20 caracteres.");
        
        if (string.IsNullOrWhiteSpace(user.Name))
            errores.AppendLine("El nombre no puede estar vacío \n");
        
        if (string.IsNullOrWhiteSpace(user.Surname))
            errores.AppendLine("El apellido no puede estar vacío.\n");
                
        if (string.IsNullOrWhiteSpace(user.Email))
            errores.AppendLine("El email no puede estar vacío.\n");
        
        if (string.IsNullOrWhiteSpace(user.Password))
            errores.AppendLine("La contraseña no puede estar vacía.\n");
        else if (user.Password.Length > 20)
        errores.AppendLine("La contraseña no puede exceder los 20 caracteres.");

        mensajeError = errores.ToString();
        return string.IsNullOrEmpty(mensajeError);
    }

    public bool Validar(string userName, string password, out string mensajeError)
    {
        var errores = new StringBuilder();

        if (string.IsNullOrWhiteSpace(userName))
            errores.AppendLine("El nombre de usuario no puede estar vacío.");
        else if (userName.Length > 20)
            errores.AppendLine("El nombre de usuario no puede exceder los 20 caracteres.");

        if (string.IsNullOrWhiteSpace(password))
            errores.AppendLine("La contraseña no puede estar vacía.");
        else if (password.Length > 20)
            errores.AppendLine("La contraseña no puede exceder los 20 caracteres.");

        mensajeError = errores.ToString();
        return string.IsNullOrEmpty(mensajeError);
    }

    //no incluye contraseña (porque agarra el hash)
    public bool ValidarModif(UserAccount user, out string mensajeError)
        {
            var errores = new StringBuilder();

            if (string.IsNullOrWhiteSpace(user.UserName))
                errores.AppendLine("El nombre de usuario no puede estar vacío.\n");
            else if (user.UserName.Length > 20)
            errores.AppendLine("El nombre de usuario no puede exceder los 20 caracteres.");
            
            if (string.IsNullOrWhiteSpace(user.Name))
                errores.AppendLine("El nombre no puede estar vacío.");
            
            if (string.IsNullOrWhiteSpace(user.Surname))
                errores.AppendLine("El apellido no puede estar vacío.");
            
            if (string.IsNullOrWhiteSpace(user.Email))
                errores.AppendLine("El email no puede estar vacío.");

            mensajeError = errores.ToString();
            return string.IsNullOrEmpty(mensajeError);
        }



}
