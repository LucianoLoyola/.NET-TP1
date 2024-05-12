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
        int id=expediente.Id;
        try
        {
            using (var sr = new StreamReader("expedientes.txt"))
            using (var sw = new StreamWriter("expedientesTemp.txt"))
            {
                string line;
                bool skipNext = false;
                skipNext=false;
                int skip=0;
                int cant=0;
                while ((line = sr.ReadLine()) != null)
                {
                    var test=id.ToString();
                    var cond=line.Contains(id.ToString());
                    if (line.Contains("Id: "+id.ToString()))
                    {
                        skipNext=true;
                        skip=5;
                        cant=5;
                        int i=0;
                        for(i=0;i<=cant;i++){
                            switch (i)
                            {
                                case 0:
                                    line="Id: "+expediente.Id;
                                    sw.WriteLine(line);
                                    break;
                                case 1:
                                    line="caratula: "+expediente.caratula;
                                    sw.WriteLine(line);
                                    break;
                                case 2:
                                    line="fechaHoraCreacion: "+expediente.fechaHoraCreacion;
                                    sw.WriteLine(line);
                                    break;
                                case 3:
                                    line="fechaHoraUModificacion: "+expediente.fechaHoraUModificacion;
                                    sw.WriteLine(line);
                                    break;
                                case 4:
                                    line="IdUsuarioMod: "+expediente.IdUsuarioMod;
                                    sw.WriteLine(line);
                                    break;
                                case 5:
                                    line="estado: "+expediente.estado;
                                    sw.WriteLine(line);
                                    break;
                                default:
                                    throw new ArgumentException("Valor de entrada no válido para Etiqueta");
                            }

                        }
                    }
                    if(skipNext){
                        skip--;
                        if(skip==0){
                            skipNext=false;

                        }
                        continue;
                    }
                    sw.WriteLine(line); // Escribir la línea al archivo temporal
                }
            }

            File.Delete("expedientes.txt"); // Eliminar el archivo original
            File.Move("expedientesTemp.txt", "expedientes.txt"); // Renombrar el archivo temporal al original
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error: " + ex.Message);
            File.Delete("expedientesTemp.txt"); // Asegurarse de eliminar el archivo temporal si ocurre un error
        }
    }
    public void EliminarExpediente(int id,List<Tramite> listaT, CasoDeUsoTramiteBaja EliminarTramite){
        Queue<int> idExpedientes = new Queue<int>();
        try
        {
            using (var sr = new StreamReader("expedientes.txt"))
            using (var sw = new StreamWriter("expedientesTemp.txt"))
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
                    if (line.Contains("Id: "+id.ToString()))
                    {
                        skipNext=true;
                        idExpedientes.Enqueue(id);
                        skip=5;
                        continue;
                    }

                    sw.WriteLine(line); // Escribir la línea al archivo temporal
                }
            }

            File.Delete("expedientes.txt"); // Eliminar el archivo original
            File.Move("expedientesTemp.txt", "expedientes.txt"); // Renombrar el archivo temporal al original
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error: " + ex.Message);
            File.Delete("expedientesTemp.txt"); // Asegurarse de eliminar el archivo temporal si ocurre un error
        }
        //Debe borrar los tramites con ese expediente asociado
         foreach (Tramite tramite in listaT)
        {
            Console.WriteLine($"Procesando trámite con expediente id: {tramite.ExpedienteId}");
            if (tramite.ExpedienteId == id)
            {
                EliminarTramite.Ejecutar(tramite.Id,1);
                Console.WriteLine("Elimine un tramite");
            }
        }


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
