using System.ComponentModel.DataAnnotations;

namespace SGE.Aplicacion.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese un usuario")]
        public string? UserName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese una contraseña")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string? Password { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirme su contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string? ConfirmPassword { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese un rol")]
        public string? Role { get; set; }  // Si los roles son predefinidos, considera usar un dropdown en el formulario
    }
}