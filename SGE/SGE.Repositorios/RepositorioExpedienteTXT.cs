namespace SGE.Repositorios;
using SGE.Aplicacion;
public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    readonly string _nombreArch = "expedientes.txt";
    int IDUnico = 0;
    int max=0;

    public void AgregarExpediente(Expediente expediente){
    // Obtener la ruta completa del archivo si _nombreArch es una ruta relativa
    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _nombreArch);
    
    // Crear un FileStream con acceso de lectura y escritura.
    using (FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
    {
        using (StreamReader sr = new StreamReader(fs))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            // Leer el archivo para encontrar el máximo ID existente
            string line;
            bool skipNext = false;
            int salida;
            //int max = 1;
            int skip=0;
            int cant=0;

            while ((line = sr.ReadLine()) != null)
            {
                if (skipNext)
                {
                    cant++;
                    if(cant==skip){
                        cant=0;
                        skipNext = false;
                    }
                    continue;
                }
                if (line.StartsWith("Id: "))
                {
                    skip=5;
                    string numberPart = line.Substring(4).Trim();
                    if (int.TryParse(numberPart, out int idValue) && idValue > max)
                    {
                            max = idValue;
                    }
                    skipNext = true; // Marcar para saltar la siguiente línea
                    continue;
                }
                else{
                    skipNext=true;
                }
            }

            // Incrementar el ID máximo encontrado para asignar un nuevo ID único
            max++;
            expediente.Id = max; // Nos aseguramos que sea único e incremental

            // Mover el puntero al final del archivo para escribir el nuevo trámite
            fs.Seek(0, SeekOrigin.End);
            sw.WriteLine("Id: "+expediente.Id);
            sw.WriteLine("caratula: "+expediente.caratula);
            sw.WriteLine("fechaHoraCreacion: "+expediente.fechaHoraCreacion);
            sw.WriteLine("fechaHoraUModificacion: "+expediente.fechaHoraUModificacion);
            sw.WriteLine("IdUsuarioMod: "+expediente.IdUsuarioMod);
            sw.WriteLine("estado: "+expediente.estado);
            //+5
        }


    }
    }
    public void ModificarExpediente(Expediente expediente){

    }
    public void EliminarExpediente(int id){

    }
    public List<Expediente> ListarExpedientes(){
        var resultado = new List<Expediente>();
        using var sr = new StreamReader(_nombreArch);
        while(!sr.EndOfStream){
            var expediente = new Expediente();
            expediente.Id = int.Parse((sr.ReadLine() ?? "").Substring(4).Trim());
            expediente.caratula = (sr.ReadLine() ?? "").Substring(10).Trim();
            expediente.fechaHoraCreacion = DateTime.Parse((sr.ReadLine() ?? "").Substring(19).Trim());
            expediente.fechaHoraUModificacion = DateTime.Parse((sr.ReadLine() ?? "").Substring(24).Trim());
            expediente.IdUsuarioMod = int.Parse((sr.ReadLine() ?? "").Substring(14).Trim());
            string estado = (sr.ReadLine() ?? "").Substring(8).Trim();
            expediente.estado=ConvertirAEstado(estado);
            resultado.Add(expediente);


        }
        return resultado;
    }

    static Estado ConvertirAEstado(string input)
    {
            switch (input)
            {
                case "Recien_iniciado":
                    return Estado.Recien_iniciado;
                case "Para_resolver":
                    return Estado.Para_resolver;
                case "Con_resolucion":
                    return Estado.Con_resolucion;
                case "En_notificacion":
                    return Estado.En_notificacion;
                case "Finalizado":
                    return Estado.Finalizado;
                default:
                    throw new ArgumentException("Valor de entrada no válido para Estado");
            }
    }
}
