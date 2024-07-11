using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces;
public interface IRepositorioUsuario{
    List<UserAccount> GetUsuarios();
    UserAccount? GetUsuario(int id);
    UserAccount? GetUsuario(string userName);
    void ModificarUsuario(UserAccount user);
    void EliminarUsuario(int id);
    void AgregarUsuario(UserAccount user);

    public void Register(UserAccount user);
    public bool Login(string username,string password,IServicioSession sesion);
    public bool Logout(IServicioSession sesion);
    
}