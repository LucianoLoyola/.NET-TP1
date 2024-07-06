namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoActualizarPerfil(IRepositorioUsuario repositorio):UserAccountUseCase(repositorio)
{
    public void Ejecutar(UserAccount userAccount)
    {
    //aquí podríamos insertar código de validación de cliente

        Repositorio.ModificarUsuario(userAccount);
    }
}

