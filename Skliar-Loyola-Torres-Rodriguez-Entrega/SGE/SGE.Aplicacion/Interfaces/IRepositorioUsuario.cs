using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces;
public interface IRepositorioUsuario{
    List<UserAccount> GetUsuarios();
    UserAccount? GetUsuario(int id);
    void ModificarUsuario(UserAccount user);
    void EliminarUsuario(int id);
    void AgregarUsuario(UserAccount user);
}