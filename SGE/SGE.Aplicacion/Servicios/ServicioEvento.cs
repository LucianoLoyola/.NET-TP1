public class ServicioEvento : IServicioEvento
{
    public event Action OnChange;

    public void Notificar()
    {
        OnChange?.Invoke();
    }
}
