using System.ComponentModel.DataAnnotations;

namespace SGE.Aplicacion.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese un usuario")]
        public string? UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese su nombre")]
        public string? Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese su apellido")]
        public string? Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese su correo electrónico")]
        public string? Email { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese una contraseña")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string? Password { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirme su contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string? ConfirmPassword { get; set; }

        
        
    }
}