using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;
public class RepositorioUsuario : IRepositorioUsuario
{
    private readonly AseguradoraContext db;

    public RepositorioUsuario(AseguradoraContext context)
    {
        db = context;
    }
    List<UserAccount> GetUsuarios(){
        return db.Usuarios.ToList();
    }
    UserAccount? GetUsuario(int id){
        return db.Usuarios.Where(u => u.Id == id).SingleOrDefault;
    }
    void ModificarUsuario(UserAccount usuario){
        //La busca por Id
        var usr_existente = db.Users.Find(usuario.Id);

        if (usr_existente == null) throw new Exception("No se encontro un usuario con ese id\n");

        usr_existente.UserName = usuario.UserName;
        usr_existente.Password = usuario.Password;
        usr_existente.Role = usuario.Role;

        db.SaveChanges();
    }
    void EliminarUsuario(int id){
        var usr_existente = db.Polizas.Find(id);
        if (usr_existente == null) throw new Exception("No se encontro la poliza con ese id");

        db.Remove(usr_existente); //se borra realmente con el db.SaveChanges()
        db.SaveChanges();
    }
    void AgregarUsuario(UserAccount usuario){
        if (usuario.UserName == null | usuario.Password == null) throw new Exception("El usuario debe tener nombre de usuario y contraseña");
        db.Add(usuario);
        db.SaveChanges();
    }
}