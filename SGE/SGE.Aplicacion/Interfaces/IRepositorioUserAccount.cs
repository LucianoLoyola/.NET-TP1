using SGE.Aplicacion;
namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
public interface IRepositorioUserAccount{
    List<UserAccount> GetUserAccounts();
    UserAccount? GetUserAccount(int id);
    void ModificarUserAccount(UserAccount user);
    void EliminarUserAccount(int id);
    void AgregarUserAccount(UserAccount user);
}