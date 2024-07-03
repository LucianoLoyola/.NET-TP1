using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;
public class RepositorioUsuario : IRepositorioUsuario
{
    private readonly SGEContext db;

    public RepositorioUsuario(SGEContext context)
    {
        db = context;
    }
    public List<UserAccount> GetUsuarios(){
        return db.Usuarios.ToList();
    }
    public UserAccount? GetUsuario(int id){
        return db.Usuarios.Where(u => u.Id == id).SingleOrDefault();
    }
    public void ModificarUsuario(UserAccount usuario){
        //La busca por Id
        var usr_existente = db.Usuarios.Find(usuario.Id);

        if (usr_existente == null) throw new Exception("No se encontro un usuario con ese id\n");

        usr_existente.UserName = usuario.UserName;
        usr_existente.Password = usuario.Password;
        usr_existente.Role = usuario.Role;

        db.SaveChanges();
    }
    public void EliminarUsuario(int id){
        var usr_existente = db.Usuarios.Find(id);
        if (usr_existente == null) throw new Exception("No se encontro usuario con ese id");

        db.Remove(usr_existente); //se borra realmente con el db.SaveChanges()
        db.SaveChanges();
    }
    public void AgregarUsuario(UserAccount usuario){
        if (usuario.UserName == null | usuario.Password == null) throw new Exception("El usuario debe tener nombre de usuario y contraseña");
        db.Add(usuario);
        db.SaveChanges();
    }
}