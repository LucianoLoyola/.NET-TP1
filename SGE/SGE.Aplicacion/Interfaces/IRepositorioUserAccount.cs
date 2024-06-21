using SGE.Aplicacion;

public interface IRepositorioUserAccount{
    List<UserAccount> GetUserAccounts();
    UserAccount? GetUserAccount(int id);
    void ModificarUserAccount(UserAccount user);
    void EliminarUserAccount(int id);
    void AgregarUserAccount(UserAccount user);
}