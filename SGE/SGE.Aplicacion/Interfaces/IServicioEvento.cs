public interface IServicioEvento
{
    event Action OnChange;
    void Notificar();
}