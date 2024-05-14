using SGE.Aplicacion;
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

var ConsultarExpedientePorId = new CasoDeUsoExpedienteConsultaPorId();
var ConsultarTramitesPorEtiqueta = new CasoDeUsoTramiteConsultaPorEtiqueta();

//se crean los expedientes
Expediente exp1 = new Expediente() {caratula="Expediente N° 1"};
Expediente exp2 = new Expediente() {caratula="Expediente N° 2"};
Expediente exp3 = new Expediente() {caratula="Expediente N° 3"};

//se crean los tramites
//no se pasan los id por parametro, ya que estos son seteados por los repositorios
Tramite tra1=new Tramite() {Contenido="Big Iron"};
Tramite tra2=new Tramite() {Contenido="Blue Moon"};
Tramite tra3=new Tramite() {Contenido="It's a Sin"};
Tramite tra4=new Tramite() {Contenido="Johnny Guitar"};
Tramite tra5=new Tramite() {Contenido="Saddle Tramp"};
Tramite tra6=new Tramite() {Contenido="Atom Bomb Baby"};

//Casos de uso con Excepciones 
try
{
    //Para los casos de uso de agregar, modificar, eliminar, se asume id=1 como permiso=permitido.
    //el Permiso no está implementado realmente en esta entrega

    //Casos de Uso Expediente y Tramite Alta--FUNCIONANDO
    //no se recibe el expediente id por parametro, ya que este se setea por los repositorios
    AgregarExpediente.Ejecutar(exp1,1,Permiso.ExpedienteAlta);
    AgregarExpediente.Ejecutar(exp2,1,Permiso.ExpedienteAlta);
    AgregarExpediente.Ejecutar(exp3,1,Permiso.ExpedienteAlta);
    //necesitan recibir el expediente, para agregar los tramites a las listas de los mismos
    AgregarTramite.Ejecutar(tra1,exp1,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra3,exp1,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra2,exp2,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra4,exp2,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra5,exp3,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra6,exp3,1,Permiso.TramiteAlta);
    

    // //Casos de Uso Listado Expedientes y Tramites--FUNCIONANDO
    var listaExpedientes = ListarExpedientes.Ejecutar();
    var listaTramites = ListarTramites.Ejecutar();

    // Console.WriteLine("------------------------------------------");
    // Console.WriteLine("Listado de expedientes:");
    // foreach(Expediente e in listaExpedientes){
    //     Console.WriteLine(e);
    // }
    // Console.WriteLine("------------------------------------------");
    // Console.WriteLine("Listado de tramites:");
    // foreach(Tramite t in listaTramites){
    //     Console.WriteLine(t);
    // }

    // // //Caso de Uso Tramite Modificacion--FUNCIONANDO
    // Console.WriteLine("------------------------------------------");
    // Console.WriteLine("Por modificar tramite con ID: "+tra1.Id);
    // tra1.Contenido="Cambio de contenido";
    // ModificarTramite.Ejecutar(tra1,exp1,1,Permiso.TramiteModificacion);

    // //Caso de Uso Expediente Modificacion--FUNCIONANDO
    // Console.WriteLine("------------------------------------------");
    // Console.WriteLine("Por modificar expediente con ID: "+exp1.Id);
    // exp1.caratula="Este es un cambio";
    // ModificarExpediente.Ejecutar(exp1,1,Permiso.ExpedienteModificacion);

    // //Caso de Uso Tramite Baja-FUNCIONANDO
    // Console.WriteLine("------------------------------------------");
    // Console.WriteLine("Por eliminar tramite con ID: "+tra2.Id);
    // EliminarTramite.Ejecutar(tra2.Id,tra2.ExpedienteId,1,Permiso.TramiteBaja);

    // //Caso de Uso Expediente Baja--FUNCIONANDO
    // Console.WriteLine("------------------------------------------");
    // Console.WriteLine("Por eliminar expediente con ID: "+exp1.Id);
    // EliminarExpediente.Ejecutar(exp1.Id,1,listaTramites,EliminarTramite,Permiso.ExpedienteBaja);


    // //Caso de Uso Consulta Expediente por ID--FUNCIONANDO
    // Console.WriteLine("------------------------------------------");
    // Console.WriteLine($"Consulta de Expediente {exp1.Id}: ");
    // Expediente expConsulta = ConsultarExpedientePorId.Ejecutar(exp1.Id,listaExpedientes,listaTramites);
    // Console.WriteLine(expConsulta);
    // Console.WriteLine($"Trámites ligados al expediente id: {exp1.Id}-------------");
    // foreach (Tramite tramiteExp in expConsulta.listaTramites)
    // {
    //     Console.WriteLine(tramiteExp);
    // }
    
    //Caso de Uso Consulta de Trámites por Etiqueta--FUNCIONANDO
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Consulta de Trámites por Etiqueta: "+Etiqueta.Despacho);
    List<Tramite>? listaConsulta = ConsultarTramitesPorEtiqueta.Ejecutar(listaTramites,Etiqueta.Despacho);
    foreach (Tramite tramite in listaConsulta)
    {
        Console.WriteLine(tramite);
    }

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