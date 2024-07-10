using System.ComponentModel.DataAnnotations;
namespace SGE.Aplicacion.ViewModels{
    public class LoginViewModel{
        [Required(AllowEmptyStrings = false, ErrorMessage="Ingrese un usuario")]
        public string? UserName {get;set;}
        [Required(AllowEmptyStrings = false, ErrorMessage="Ingrese una contraseña")]
        public string? Password{get;set;}
    }
}