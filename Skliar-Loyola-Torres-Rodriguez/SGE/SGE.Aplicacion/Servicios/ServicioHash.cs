using System.Security.Cryptography;
using System.Text;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioHash : IServicioHash
    {
        public string GetHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2")); //agrega la cadena al final del Stringbuilder
                }
                return builder.ToString();
            }
        }
    }
}

