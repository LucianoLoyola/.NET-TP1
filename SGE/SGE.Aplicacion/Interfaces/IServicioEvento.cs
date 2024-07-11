public interface IServicioEvento
{
    event Action OnChange;
    void Notify();
}