using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion;


public class ServicioSession : IServicioSession{
    public UserAccount? User {get;set;}
    public void SetUser(UserAccount user){
        User=user;
    }


}