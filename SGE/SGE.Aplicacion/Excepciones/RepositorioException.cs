public class RepositorioException : Exception
{
    public RepositorioException(string message) : base(message)
    {
    }

     // Caso de excepción interna en catch. "Exception" mantiene referencia a la excepcion original
    public RepositorioException(string message, Exception innerException) : base(message, innerException)
    {
    }
}