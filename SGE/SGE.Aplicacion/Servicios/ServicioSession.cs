using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion;


public class ServicioSession : IServicioSession{
    public UserAccount? user {get;set;}
    public void SetUser(UserAccount user){
        this.user=user;
    }


}