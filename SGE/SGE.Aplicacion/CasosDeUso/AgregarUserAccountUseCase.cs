namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class AgregarUsuarioUseCase(IRepositorioUsuario repositorio, UsuarioValidador validador):UserAccountUseCase(repositorio)
{
    public void Ejecutar(UserAccount userAccount)
    {
        if(!validador.Validar(userAccount,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        else try{
            Repositorio.AgregarUsuario(userAccount);
        }
        catch(Exception error){
            Console.WriteLine($"Error al registrarse: {error.Message}");
        }
        
    }
}