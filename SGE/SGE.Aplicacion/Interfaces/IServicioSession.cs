using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces
{
    public interface IServicioSession
    {
        UserAccount? User {get;set;}
        public void SetUser(UserAccount user);
    }
}