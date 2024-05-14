﻿using SGE.Aplicacion;
using SGE.Repositorios;

//se crean los repositorios
IExpedienteRepositorio repoE = new RepositorioExpedienteTXT();
ITramiteRepositorio repoT = new RepositorioTramiteTXT();
//se crean los servicios de autorización provisoria y actualización automatica de expediente
IServicioAutorizacion servicioAuthProvisorio = new ServicioAutorizacionProvisiorio();
IServicioActualizacionEstado servicioActualizacionEstado = new ServicioActualizacionEstado();
//se crean los casos de uso
var AgregarExpediente = new CasoDeUsoExpedienteAlta(repoE, new ExpedienteValidador(),servicioAuthProvisorio);
var ListarExpedientes = new CasoDeUsoListarExpedientes(repoE);
var EliminarExpediente=new CasoDeUsoExpedienteBaja(repoE, servicioAuthProvisorio);
var ModificarExpediente=new CasoDeUsoExpedienteModificacion(repoE, new ExpedienteValidador(), servicioAuthProvisorio);

var AgregarTramite = new CasoDeUsoTramiteAlta(repoT,repoE, new TramiteValidador(), servicioAuthProvisorio,servicioActualizacionEstado);
var ListarTramites = new CasoDeUsoListarTramites(repoT);
var EliminarTramite=new CasoDeUsoTramiteBaja(repoT,repoE, servicioAuthProvisorio,servicioActualizacionEstado);
var ModificarTramite=new CasoDeUsoTramiteModificacion(repoT,repoE, new TramiteValidador(), servicioAuthProvisorio,servicioActualizacionEstado);

//se crean los expedientes
Expediente exp1 = new Expediente() {caratula="Expediente N° 1"};
Expediente exp2 = new Expediente() {caratula="Expediente N° 2"};
Expediente exp3 = new Expediente() {caratula="Expediente N° 3"};

//se crean los tramites
Tramite tra1=new Tramite() {Contenido="Big Iron", ExpedienteId=exp1.Id};
Tramite tra2=new Tramite() {Contenido="Blue Moon", ExpedienteId=exp1.Id};
Tramite tra3=new Tramite() {Contenido="It's a Sin", ExpedienteId=exp2.Id};
Tramite tra4=new Tramite() {Contenido="Johnny Guitar", ExpedienteId=exp2.Id};
Tramite tra5=new Tramite() {Contenido="Saddle Tramp", ExpedienteId=exp3.Id};
Tramite tra6=new Tramite() {Contenido="Atom Bomb Baby", ExpedienteId=exp3.Id};

//Casos de uso con Excepciones 
try
{
    //Para los casos de uso de agregar, modificar, eliminar, se asume id=1 como permiso=permitido.
    //el Permiso no está implementado realmente en esta entrega

    //Casos de Uso Expediente y Tramite Alta
    AgregarExpediente.Ejecutar(exp1,exp1.Id,1,Permiso.ExpedienteAlta);
    AgregarExpediente.Ejecutar(exp2,exp2.Id,1,Permiso.ExpedienteAlta);
    AgregarExpediente.Ejecutar(exp3,exp3.Id,1,Permiso.ExpedienteAlta);
    AgregarTramite.Ejecutar(tra1,exp1.Id,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra2,exp2.Id,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra3,exp1.Id,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra4,exp2.Id,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra5,exp3.Id,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra6,exp3.Id,1,Permiso.TramiteAlta);

    //Caso de Uso Tramite Baja
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por eliminar tramite con ID: "+tra2.Id);
    EliminarTramite.Ejecutar(tra2.Id,tra2.ExpedienteId,1,Permiso.TramiteBaja);

    //Casos de Uso Listado Expedientes y Tramites
    var lista = ListarExpedientes.Ejecutar();
    var listaTramites = ListarTramites.Ejecutar();

    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Listado de expedientes:");
    foreach(Expediente e in lista){
        Console.WriteLine(e);
    }
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Listado de tramites:");
    foreach(Tramite t in listaTramites){
        Console.WriteLine(t);
    }

    //Caso de Uso Expediente Baja
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por eliminar expediente con ID: "+exp1.Id);
    EliminarExpediente.Ejecutar(exp1.Id,1,listaTramites,EliminarTramite,Permiso.ExpedienteBaja);

    //Caso de Uso Tramite Modificacion
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por modificar tramite con ID: "+tra1.Id);
    tra1.Contenido="Cambio de contenido";
    ModificarTramite.Ejecutar(tra1,tra1.ExpedienteId,1,Permiso.TramiteModificacion);

    //Caso de Uso Expediente Modificacion
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por modificar expediente con ID: "+exp1.Id);
    exp1.caratula="Este es un cambio";
    ModificarExpediente.Ejecutar(exp1,1,Permiso.ExpedienteModificacion);

    //Caso de Uso Expediente Modificacion
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por modificar expediente con ID: "+exp1.Id);
    exp1.caratula="Este es un cambio";
    ModificarExpediente.Ejecutar(exp1,1,Permiso.ExpedienteModificacion);

    //Caso de Uso Expediente Modificacion
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por modificar expediente con ID: "+exp1.Id);
    exp1.caratula="Este es un cambio";
    ModificarExpediente.Ejecutar(exp1,1,Permiso.ExpedienteModificacion);

    //Faltan agregar los casos de uso Consulta por ID y Consulta por Etiqueta (ya estan implementados)
    
}
catch(AutorizacionException authException) {
Console.WriteLine($"Operación cancelada - Autorización Denegada\n{authException.Message}");
}
catch(ValidacionException validException) {
Console.WriteLine($"Operación cancelada - Validación\n{validException.Message}");
}
catch(RepositorioException repoException) {
Console.WriteLine($"Operación cancelada - Objeto Inexistente\n{repoException.Message}");
}
catch (System.Exception ex)
{
    Console.WriteLine(ex.Message);
}



