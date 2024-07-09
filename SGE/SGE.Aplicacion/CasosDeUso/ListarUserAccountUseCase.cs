namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class ListarUserAccountUseCase(IRepositorioUsuario repositorio):UserAccountUseCase(repositorio)
{
    public List<UserAccount>? Ejecutar()
    {
    //aquí podríamos insertar código de validación de cliente
        List<UserAccount>? usuarios = Repositorio.GetUsuarios();

            return usuarios;

    }
}