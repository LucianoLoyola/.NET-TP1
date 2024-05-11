namespace SGE.Repositorios;

using System.ComponentModel.DataAnnotations;
using SGE.Aplicacion;
public class RepositorioTramiteTXT : ITramiteRepositorio
{
    readonly string _nombreArch = "tramites.txt";
    int IDUnico = 0;
    int max=0;

    public void AgregarTramite(Tramite tramite, int idExpediente){
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
                if (line.StartsWith("id: "))
                {
                    skip=6;
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
            tramite.Id = max; // Nos aseguramos que sea único e incremental

            // Mover el puntero al final del archivo para escribir el nuevo trámite
            fs.Seek(0, SeekOrigin.End);
            sw.WriteLine("id: "+tramite.Id);
            sw.WriteLine("expedienteID: "+tramite.ExpedienteId);
            sw.WriteLine("etiqueta: "+tramite.etiqueta);
            sw.WriteLine("contenido: "+tramite.Contenido);
            sw.WriteLine("fechaHoraCreacion: "+tramite.fechaHoraCreacion);
            sw.WriteLine("fechaHoraUltimaModificacion: "+tramite.fechaHoraUltimaModificacion);
            sw.WriteLine("idUsuarioMod: "+tramite.IdUsuarioMod);
            //+7
        }
    }
    }
    public void ModificarTramite(Tramite tramite){

    }
    public void EliminarTramite(int id){
        try
        {
            using (var sr = new StreamReader("tramites.txt"))
            using (var sw = new StreamWriter("tramitesTemp.txt"))
            {
                string line;
                bool skipNext = false;
                skipNext=false;
                int skip=0;
                int cant=0;
                while ((line = sr.ReadLine()) != null)
                {
                    if(skipNext){
                        cant++;
                        if(cant==skip){
                            cant=0;
                            skipNext=false;
                        }
                        continue;
                    }
                    var test=id.ToString();
                    var cond=line.Contains(id.ToString());
                    if (line.Contains("id: "+id.ToString()))
                    {
                        skipNext=true;
                        skip=8;
                        continue;
                    }

                    sw.WriteLine(line); // Escribir la línea al archivo temporal
                }
            }

            File.Delete("tramites.txt"); // Eliminar el archivo original
            File.Move("tramitesTemp.txt", "tramites.txt"); // Renombrar el archivo temporal al original
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error: " + ex.Message);
            File.Delete("tramitesTemp.txt"); // Asegurarse de eliminar el archivo temporal si ocurre un error
        }


    }

    public List<Tramite> ListarTramites(){
        var resultado = new List<Tramite>();
        using var sr = new StreamReader(_nombreArch);
        while(!sr.EndOfStream){
            var tramite = new Tramite();
            tramite.Id = int.Parse((sr.ReadLine() ?? "").Substring(4).Trim());
            tramite.ExpedienteId = int.Parse((sr.ReadLine() ?? "").Substring(14).Trim());
            
            string etiqueta = (sr.ReadLine() ?? "").Substring(10).Trim();
            tramite.etiqueta=ConvertirAEtiqueta(etiqueta);

            tramite.Contenido = (sr.ReadLine() ?? "").Substring(11).Trim();
            tramite.fechaHoraCreacion = DateTime.Parse((sr.ReadLine() ?? "").Substring(19).Trim());
            tramite.fechaHoraUltimaModificacion = DateTime.Parse((sr.ReadLine() ?? "").Substring(29).Trim());
            tramite.IdUsuarioMod = int.Parse((sr.ReadLine() ?? "").Substring(14).Trim());


            resultado.Add(tramite);
        }
        return resultado;
    }

    static Etiqueta ConvertirAEtiqueta(string input)
    {
        switch (input)
        {
            case "Escrito_presentado":
                return Etiqueta.Escrito_presentado;
            case "Pase_a_estudio":
                return Etiqueta.Pase_a_estudio;
            case "Despacho":
                return Etiqueta.Despacho;
            case "Resolución":
                return Etiqueta.Resolución;
            case "Notificación":
                return Etiqueta.Notificación;
            case "Pase_al_Archivo":
                return Etiqueta.Pase_al_Archivo;
            default:
                throw new ArgumentException("Valor de entrada no válido para Etiqueta");
        }
    }
}
