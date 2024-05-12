using SGE.Aplicacion;
using SGE.Repositorios;

//configuro las dependencias 
IExpedienteRepositorio repo = new RepositorioExpedienteTXT();
ITramiteRepositorio repoT = new RepositorioTramiteTXT();
//creo los casos de uso 
var AgregarExpediente = new CasoDeUsoExpedienteAlta(repo, new ExpedienteValidador());
var ListarExpedientes = new CasoDeUsoListarExpedientes(repo);
var EliminarExpediente=new CasoDeUsoExpedienteBaja(repo);
var ModificarExpediente=new CasoDeUsoExpedienteModificacion(repo);

var AgregarTramite = new CasoDeUsoTramiteAlta(repoT, new TramiteValidador());
var ListarTramites = new CasoDeUsoListarTramites(repoT);
var EliminarTramite=new CasoDeUsoTramiteBaja(repoT);
var ModificarTramite=new CasoDeUsoTramiteModificacion(repoT);

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
    //Los casos de uso deben recibir el ID del usuario. La validación provisoria dice que al recibir '1', lo valida como correcto. Leer 'IServicioAutorizacion' y provisorio
    AgregarExpediente.Ejecutar(exp,exp.Id,1);
    AgregarExpediente.Ejecutar(exp2,exp2.Id,1);
    AgregarExpediente.Ejecutar(exp3,exp3.Id,1);
    AgregarTramite.Ejecutar(tra1,exp.Id,1);
    AgregarTramite.Ejecutar(tra2,exp2.Id,1);
    AgregarTramite.Ejecutar(tra3,exp.Id,1);
    AgregarTramite.Ejecutar(tra4,exp2.Id,1);
    AgregarTramite.Ejecutar(tra5,exp3.Id,1);
    AgregarTramite.Ejecutar(tra6,exp3.Id,1);
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por eliminar tramite con ID: "+tra2.Id);
    EliminarTramite.Ejecutar(tra2.Id,1);
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
    EliminarExpediente.Ejecutar(exp.Id,1,listaDeTramites,EliminarTramite);
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por modificar tramite con ID: "+tra1.Id);//ESTA FUNCIONANDO MAL
    tra1.Contenido="Cambio de contenido";
    ModificarTramite.Ejecutar(tra1,1);
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por modificar expediente con ID: "+exp.Id);//ESTA FUNCIONANDO MAL
    exp.caratula="Este es un cambio";
    ModificarExpediente.Ejecutar(exp,1);
    
}
catch (System.Exception ex)
{
    Console.WriteLine(ex.Message);
}

