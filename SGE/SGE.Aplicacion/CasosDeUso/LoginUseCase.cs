using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class LoginUseCase(IRepositorioUsuario repo,IServicioHash servicioHash){
    public bool Ejecutar(string username,string password, IServicioSession sesion){
        string hash= servicioHash.GetHashSha256(password);
        if(repo.Login(username,hash,sesion)) return true;
        else return false;
    }

}