namespace SGE.Aplicacion;

class CambioEstadoExpediente(IExpedienteRepositorio repo) : ICambioEstadoExpediente 
{

    public void actualizarExpediente(int idExpediente)
    {
        Expediente expediente = null;
        List<Expediente> lista = repo.ListarExpedientes();
        foreach (Expediente exp in lista)
        {
            if(idExpediente == exp.Id)
            {
                expediente = exp;
            }
        }

        if(expediente != null)
        {
            if (!(expediente.listaTramites.Count == 0))
            {
                Tramite tramite = expediente.listaTramites.Last();
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
            }
            else
            {
                Console.WriteLine("El expediente no tiene tramites asociados");
            }
        }
        else
        {
            Console.WriteLine("No se encontró un expediente con este id");
        }
    }

}