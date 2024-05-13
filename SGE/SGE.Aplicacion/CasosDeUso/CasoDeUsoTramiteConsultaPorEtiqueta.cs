namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta()
{
    public List<Tramite> Ejecutar(List<Tramite> lista, Etiqueta etiqueta)
    {
        List<Tramite> listaNueva = new List<Tramite>();
        foreach (Tramite tr in lista)
        {
            if (tr.etiqueta == etiqueta)
            {
                listaNueva.Add(tr);
            }
        }
         // Si no se encontraron trámites con la etiqueta especificada, lanza una excepción
        if (listaNueva.Count == 0)
        {
            throw new RepositorioException($"No existe ningún trámite con la etiqueta {etiqueta}");
        }
        return listaNueva;
    }
}

