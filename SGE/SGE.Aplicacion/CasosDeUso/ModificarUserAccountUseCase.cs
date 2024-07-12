namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;

public class ModificarUserAccountUseCase(IRepositorioUsuario repositorio, UsuarioValidador validador, ServicioHash servicioHash):UserAccountUseCase(repositorio)
{
    public void Ejecutar(UserAccount userAccount, string newPassword)
    {
        userAccount.Password = servicioHash.GetHashSha256(newPassword);
    //aquí podríamos insertar código de validación de cliente
        if(!validador.Validar(userAccount,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else{
            Repositorio.ModificarUsuario(userAccount);
        }
    }
}