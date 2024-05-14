using SGE.Aplicacion;
using SGE.Repositorios;

//configuro las dependencias 
IExpedienteRepositorio repoE = new RepositorioExpedienteTXT();
ITramiteRepositorio repoT = new RepositorioTramiteTXT();
IServicioAutorizacion servicioAuthProvisorio = new ServicioAutorizacionProvisiorio();
IServicioActualizacionEstado servicioActualizacionEstado = new ServicioActualizacionEstado();
//creo los casos de uso 
var AgregarExpediente = new CasoDeUsoExpedienteAlta(repoE, new ExpedienteValidador(),servicioAuthProvisorio);
var ListarExpedientes = new CasoDeUsoListarExpedientes(repoE);
var EliminarExpediente=new CasoDeUsoExpedienteBaja(repoE, servicioAuthProvisorio);
var ModificarExpediente=new CasoDeUsoExpedienteModificacion(repoE, new ExpedienteValidador(), servicioAuthProvisorio);

var AgregarTramite = new CasoDeUsoTramiteAlta(repoT,repoE, new TramiteValidador(), servicioAuthProvisorio,servicioActualizacionEstado);
var ListarTramites = new CasoDeUsoListarTramites(repoT);
var EliminarTramite=new CasoDeUsoTramiteBaja(repoT,repoE, servicioAuthProvisorio,servicioActualizacionEstado);
var ModificarTramite=new CasoDeUsoTramiteModificacion(repoT,repoE, new TramiteValidador(), servicioAuthProvisorio,servicioActualizacionEstado);

//creo los expedientes
Expediente exp = new Expediente() {caratula="Expediente N° 1"};
Expediente exp2 = new Expediente() {caratula="Expediente N° 2"};
Expediente exp3 = new Expediente() {caratula="Expediente N° 3"};

//Creo los trámites
Tramite tra1=new Tramite() {Contenido="Big Iron", ExpedienteId=exp.Id};
Tramite tra2=new Tramite() {Contenido="Blue Moon", ExpedienteId=exp.Id};
Tramite tra3=new Tramite() {Contenido="It's a Sin", ExpedienteId=exp2.Id};
Tramite tra4=new Tramite() {Contenido="Johnny Guitar", ExpedienteId=exp2.Id};
Tramite tra5=new Tramite() {Contenido="Saddle Tramp", ExpedienteId=exp3.Id};
Tramite tra6=new Tramite() {Contenido="Atom Bomb Baby", ExpedienteId=exp3.Id};
List<Tramite> listaDeTramites = new List<Tramite>();
listaDeTramites.Add(tra1);
listaDeTramites.Add(tra2);
listaDeTramites.Add(tra3);
listaDeTramites.Add(tra4);
listaDeTramites.Add(tra5);
listaDeTramites.Add(tra6);

//ejecuto los casos de uso con validaciones 
try
{
    //Los casos de uso deben recibir el ID del usuario y un permiso. El enum Permiso no se utiliza realmente por ahora se asume id=1 permitido
    AgregarExpediente.Ejecutar(exp,exp.Id,1,Permiso.ExpedienteAlta);
    AgregarExpediente.Ejecutar(exp2,exp2.Id,1,Permiso.ExpedienteAlta);
    AgregarExpediente.Ejecutar(exp3,exp3.Id,1,Permiso.ExpedienteAlta);
    AgregarTramite.Ejecutar(tra1,exp.Id,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra2,exp2.Id,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra3,exp.Id,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra4,exp2.Id,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra5,exp3.Id,1,Permiso.TramiteAlta);
    AgregarTramite.Ejecutar(tra6,exp3.Id,1,Permiso.TramiteAlta);
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por eliminar tramite con ID: "+tra2.Id);
    EliminarTramite.Ejecutar(tra2.Id,tra2.ExpedienteId,1,Permiso.TramiteBaja);
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

    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por eliminar expediente con ID: "+exp.Id);
    EliminarExpediente.Ejecutar(exp.Id,1,listaDeTramites,EliminarTramite,Permiso.ExpedienteBaja);
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por modificar tramite con ID: "+tra1.Id);//ESTA FUNCIONANDO MAL
    tra1.Contenido="Cambio de contenido";
    ModificarTramite.Ejecutar(tra1,tra1.ExpedienteId,1,Permiso.TramiteModificacion);
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por modificar expediente con ID: "+exp.Id);//ESTA FUNCIONANDO MAL
    exp.caratula="Este es un cambio";
    ModificarExpediente.Ejecutar(exp,1,Permiso.ExpedienteModificacion);
    
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



