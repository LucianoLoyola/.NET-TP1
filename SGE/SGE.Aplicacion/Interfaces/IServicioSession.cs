using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces

{
    public interface IServicioSession
    {
        UserAccount? User {get;}
        void SetUser(UserAccount user);
        void ClearUser();
    }
    
}
