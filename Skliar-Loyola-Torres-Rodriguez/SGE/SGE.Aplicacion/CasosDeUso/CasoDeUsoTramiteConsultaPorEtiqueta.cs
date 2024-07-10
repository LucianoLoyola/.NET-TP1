namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoTramiteConsultaPorEtiqueta()
{
    public List<Tramite> Ejecutar(List<Tramite> listaTramites, Etiqueta Etiqueta)
    {
        List<Tramite> listaNueva = new List<Tramite>();
        foreach (Tramite tr in listaTramites)
        {
            if (tr.Etiqueta == Etiqueta)
            {
                listaNueva.Add(tr);
            }
        }
         // Si no se encontraron trámites con la Etiqueta especificada, lanza una excepción
        if (listaNueva.Count == 0)
        {
            throw new RepositorioException($"No existe ningún trámite con la Etiqueta {Etiqueta}");
        }
        return listaNueva;
    }
}

