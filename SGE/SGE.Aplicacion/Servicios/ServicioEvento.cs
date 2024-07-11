public class ServicioEvento : IServicioEvento
{
    public event Action OnChange;

    public void Notify()
    {
        OnChange?.Invoke();
    }
}
