public class ValidacionException : Exception
{
    public ValidacionException(string message) : base(message)
    {
    }

    // Caso de excepción interna en catch. "Exception" mantiene referencia a la excepcion original
    public ValidacionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}