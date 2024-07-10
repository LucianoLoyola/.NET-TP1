using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
namespace SGE.Repositorios;
public class RepositorioUsuario : IRepositorioUsuario
{
    private readonly SGEContext db;

    public RepositorioUsuario(SGEContext context)
    {
        db = context;
    }
    public List<UserAccount> GetUsuarios(){
        return db.Usuarios.Include(u => u.Permisos).ToList();
    }
    public UserAccount? GetUsuario(int id){
        return db.Usuarios.Where(u => u.Id == id).SingleOrDefault();
    }
    public UserAccount? GetUsuario(string userName){
        return db.Usuarios.Where(u => u.UserName == userName).SingleOrDefault();
    }
    
    public void ModificarUsuario(UserAccount usuario){
        //La busca por Id
        var usr_existente = db.Usuarios.Find(usuario.Id) ?? throw new RepositorioException("No se encontro un usuario con ese id\n");
        usr_existente.UserName = usuario.UserName;
        usr_existente.Password = usuario.Password;
        usr_existente.Role = usuario.Role;
        usr_existente.Email= usuario.Email;
        usr_existente.Name= usuario.Name;
        usr_existente.Surname= usuario.Surname;

        db.SaveChanges();
    }
    public void EliminarUsuario(int id){
        var usr_existente = db.Usuarios.Find(id);
        if (usr_existente == null) throw new RepositorioException("No se encontro usuario con ese id");
        db.Remove(usr_existente); //se borra realmente con el db.SaveChanges()
        db.SaveChanges();
    }
    public void AgregarUsuario(UserAccount usuario){
        db.Add(usuario);
        db.SaveChanges();
    }
}