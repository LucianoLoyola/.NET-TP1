using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class LogoutUseCase(IRepositorioUsuario repo,IServicioHash servicioHash){
    public bool Ejecutar(IServicioSession sesion){
        if(repo.Logout(sesion)) return true;
        else return false;
    }

}