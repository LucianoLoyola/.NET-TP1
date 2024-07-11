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
        List<UserAccount> lista = db.Usuarios.Include(u => u.Permisos).ToList();
        if(!lista.Any()) throw new RepositorioException($"No existen usuarios");
        else return lista;
    }
    public UserAccount? GetUsuario(int id){
        UserAccount user = db.Usuarios.Include(u => u.Permisos).Where(u => u.Id == id).SingleOrDefault();
        if(user == null) throw new RepositorioException($"No se encontró un usuario con el Id {id}");
        else return user;
    }
    public UserAccount? GetUsuario(string userName){
        UserAccount user = db.Usuarios.Include(u => u.Permisos).SingleOrDefault(u => u.UserName == userName);
        if(user == null) throw new RepositorioException($"No se encontró un usuario con el Username {userName}");
        else return user;
    }

    public void Register(UserAccount user){
        // using var db= new BaseContext();
        db.Usuarios.Add(user);
        db.SaveChanges();
    }
    public bool Login(string username,string password, IServicioSession sesion){
        // using var db=new BaseContext();
        UserAccount? user= db.Usuarios.Include(u => u.Permisos).Where(u => u.UserName == username && u.Password== password).SingleOrDefault();
        if(user != null){
            sesion.SetUser(user);
            return true;
        }
        else{
            sesion.ClearUser();
            return false;
        } 
    }
    public bool Logout(IServicioSession sesion){
        // using var db=new BaseContext();
        sesion.ClearUser();
        return true;

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