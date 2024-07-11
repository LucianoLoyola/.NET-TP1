namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class ModificarUserAccountUseCase(IRepositorioUsuario repositorio, UsuarioValidador validador):UserAccountUseCase(repositorio)
{
    public void Ejecutar(UserAccount userAccount)
    {
    //aquí podríamos insertar código de validación de cliente
        if(!validador.Validar(userAccount,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else{
            Repositorio.ModificarUsuario(userAccount);
        }
    }
}