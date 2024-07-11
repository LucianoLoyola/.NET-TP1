using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces

{
    public interface IServicioSession
    {
        UserAccount? User {get;set;}
        void SetUser(UserAccount user);
        void ClearUser();
    }
    
}
