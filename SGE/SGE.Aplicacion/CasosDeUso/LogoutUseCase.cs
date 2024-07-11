using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class LogoutUseCase(IRepositorioUsuario repo,IServicioHash servicioHash){
    public UserAccount? Ejecutar(string username,string password){
        string hash= servicioHash.GetHashSha256(password);
        return repo.Login(username,hash);
    }
}