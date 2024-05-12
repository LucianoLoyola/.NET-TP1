public class AutorizacionException : Exception
{
    public AutorizacionException(string message) : base(message)
    {
    }

     // Caso de excepción interna en catch. "Exception" mantiene referencia a la excepcion original
    public AutorizacionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}