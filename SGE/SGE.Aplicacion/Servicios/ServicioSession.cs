using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion;

public class ServicioSession : IServicioSession
{
    private readonly IServicioEvento _servicioEvento;
    private UserAccount? _user;

    public ServicioSession(IServicioEvento servicioEvento)
    {
        _servicioEvento = servicioEvento ?? throw new ArgumentNullException(nameof(servicioEvento));
    }

    public UserAccount? User 
    {
        get => _user;
        private set 
        {
            _user = value;
            _servicioEvento.Notificar();
        }
    }

    public void SetUser(UserAccount user)
    {
        User = user ?? throw new ArgumentNullException(nameof(user));
    }

    public void ClearUser()
    {
        User = null;
    }
}