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
        return listaNueva;
    }
}