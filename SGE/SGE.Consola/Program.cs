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
Expediente exp = new Expediente() {caratula="Random"};
Expediente exp2 = new Expediente() {caratula="Prueba"};

//Creo los trámites
Tramite tra1=new Tramite() {Contenido="Test", ExpedienteId=40};
Tramite tra2=new Tramite() {Contenido="Xes", ExpedienteId=41};
Tramite tra3=new Tramite() {Contenido="Res", ExpedienteId=42};
Tramite tra4=new Tramite() {Contenido="Mes", ExpedienteId=43};
List<Tramite> listaDeTramites = new List<Tramite>();
listaDeTramites.Add(tra1);
listaDeTramites.Add(tra2);
listaDeTramites.Add(tra3);
listaDeTramites.Add(tra4);

//ejecuto los casos de uso con validaciones 
try
{
    //Los casos de uso deben recibir el ID del usuario. La validación provisoria dice que al recibir '1', lo valida como correcto. Leer 'IServicioAutorizacion' y provisorio
    AgregarExpediente.Ejecutar(exp,exp.Id,1);
    AgregarExpediente.Ejecutar(exp2,exp2.Id,1);
    AgregarTramite.Ejecutar(tra1,exp.Id,1);
    AgregarTramite.Ejecutar(tra2,exp2.Id,1);
    AgregarTramite.Ejecutar(tra3,exp.Id,1);
    AgregarTramite.Ejecutar(tra4,exp2.Id,1);
    EliminarTramite.Ejecutar(tra2.Id,1);
    var lista = ListarExpedientes.Ejecutar();
    Console.WriteLine("------------------------------------------");
    var listaTramites = ListarTramites.Ejecutar();
    foreach(Expediente e in lista){
        Console.WriteLine(e);
    }
    foreach(Tramite t in listaTramites){
        Console.WriteLine(t);
    }
    Console.WriteLine("------------------------------------------");
    //Console.WriteLine("Por eliminar expediente con ID: "+exp.Id);
    //EliminarExpediente.Ejecutar(exp.Id,1,listaDeTramites,EliminarTramite);
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por modificar tramite con ID: "+tra1.Id);
    tra1.Contenido="Cambio de contenido";
    ModificarTramite.Ejecutar(tra1,1);
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Por modificar expediente con ID: "+exp.Id);
    exp.caratula="Este es un cambio";
    ModificarExpediente.Ejecutar(exp,1);
    
}
catch (System.Exception ex)
{
    Console.WriteLine(ex.Message);
}

