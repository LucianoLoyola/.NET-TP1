using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class LoginUseCase(IRepositorioUsuario repo,UsuarioValidador validador, IServicioHash servicioHash){
    public bool Ejecutar(string username,string password, IServicioSession sesion){
        if(!validador.Validar(username,password,out string mensajeError)){
            throw new ValidacionException(mensajeError);
        }
        string hash= servicioHash.GetHashSha256(password);
        if(repo.Login(username,hash,sesion)) return true;
        else return false;
    }

}