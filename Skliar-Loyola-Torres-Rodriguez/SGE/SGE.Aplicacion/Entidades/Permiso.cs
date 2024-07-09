namespace SGE.Aplicacion.Entidades;

public class Permiso
{
    public int Id { get; set; }
    public TipoPermiso tipoPermiso { get; set; }
    
    // Sobrecargamos Equals para comparar Permiso basado en TipoPermiso (puesto que cada usuario tiene una lista de permisos que pueden llamarse igual pero ser diferentes objetos)
    public override bool Equals(object? obj)
    {
        if (obj is Permiso permiso)
        {
            return tipoPermiso == permiso.tipoPermiso;
        }
        return false;
    }

        // Sobrecargamos GetHashCode para asegurarnos que los objetos se comporten correctamente en colecciones
        public override int GetHashCode()
        {
            return tipoPermiso.GetHashCode();
        }

}