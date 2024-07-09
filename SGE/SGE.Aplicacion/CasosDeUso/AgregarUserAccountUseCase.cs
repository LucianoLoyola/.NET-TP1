namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class AgregarUsuarioUseCase(IRepositorioUsuario repositorio, UsuarioValidador validador):UserAccountUseCase(repositorio)
{
    public void Ejecutar(UserAccount userAccount)
    {
    //aquí podríamos insertar código de validación de cliente
        var mensajeError="";
        if(!validador.Validar(userAccount,out mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else{
            Repositorio.AgregarUsuario(userAccount);
        }
    }
}