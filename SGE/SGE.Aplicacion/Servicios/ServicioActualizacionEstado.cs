using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion;

public class ServicioActualizacionEstado : IServicioActualizacionEstado 
{

    public void actualizarEstadoExpediente(int idExpediente, IRepositorioExpediente repo)
    {
        Expediente? expediente = repo.GetExpedientePorId(idExpediente);
        List<Tramite> lista = expediente.listaTramites;
        //busca expediente por id
        //si encuentra un expediente
        if(expediente != null)
        {
            //si el expediente tiene tramite/s
            if (lista != null && lista.Count > 0)
            {
                //modifica el estado del expediente, dependiendo de la Etiqueta del último trámite
                Tramite tramite = lista.Last();
                switch (tramite.Etiqueta)
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
                        expediente.estado = Estado.Recien_iniciado;
                        repo.ModificarExpediente(expediente);
                        break;
                }
            }
        }
    }



}
