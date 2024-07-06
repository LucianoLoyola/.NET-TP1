using System.ComponentModel.DataAnnotations;

namespace SGE.Aplicacion.ViewModels
{
    public class UpdateViewModel
    {
        public string? UserName { get; set; }
        
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }
        
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string? Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string? ConfirmPassword { get; set; }
        
        public string? Role { get; set; }  // Si los roles son predefinidos, considera usar un dropdown en el formulario
    }
}