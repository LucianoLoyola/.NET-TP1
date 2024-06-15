using SGE.Aplicacion;

public interface IRepositorioUserAccount{
    List<UserAccount> GetUserAccounts();
    IRepositorioUserAccount? GetUserAccount(int id);
    void ModificarUserAccount(UserAccount user);
    void EliminarUserAccount(int id);
    void AgregarUserAccount(IRepositorioUserAccount user);
}