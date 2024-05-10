﻿namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpediente(Expediente expediente);
    void ModificarExpediente(Expediente expediente);
    void EliminarExpediente(int id);
    List<Expediente> ListarExpediente();
}
