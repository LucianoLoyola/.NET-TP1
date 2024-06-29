namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
public interface IServicioAutorizacion
{
bool PoseeElPermiso(int IdUsuario, Permiso permiso);
}