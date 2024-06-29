using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion;

public class ServicioActualizacionEstado : IServicioActualizacionEstado 
{

    public void actualizarEstadoExpediente(int idExpediente, IExpedienteRepositorio repo, List<Tramite>? listaTramites)
    {
        Expediente? expediente = null;
        List<Expediente> lista = repo.ListarExpedientes();
        //busca expediente por id
        foreach (Expediente exp in lista)
        {
            if(idExpediente == exp.Id)
            {
                expediente = exp;
            }
        }
        //si encuentra un expediente
        if(expediente != null)
        {
            //si el expediente tiene tramite/s
            if (listaTramites != null && listaTramites.Count > 0)
            {
                //modifica el estado del expediente, dependiendo de la etiqueta del último trámite
                Tramite tramite = listaTramites.Last();
                switch (tramite.etiqueta)
                {
                    case Etiqueta.Resolución:
                        expediente.estado = Estado.Con_resolucion;
                        repo.ModificarExpediente(expediente);
                        break;
                    case Etiqueta.Pase_a_estudio:
                        expediente.estado = Estado.Para_resolver;
                        repo.ModificarExpediente(expediente);
                        break;
                    case Etiqueta.Pase_al_Archivo:
                        expediente.estado = Estado.Finalizado;
                        repo.ModificarExpediente(expediente);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Estado de expediente actualizado");
            }
            else
            {
                Console.WriteLine("El expediente no tiene tramites asociados");
            }
        }
        else
        {
            Console.WriteLine("No se encontró un expediente asociado al tramite");
        }
    }

}
