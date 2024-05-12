using SGE.Aplicacion;
using SGE.Repositorios;

//configuro las dependencias 
IExpedienteRepositorio repo = new RepositorioExpedienteTXT();
ITramiteRepositorio repoT = new RepositorioTramiteTXT();
//creo los casos de uso 
var AgregarExpediente = new CasoDeUsoExpedienteAlta(repo, new ExpedienteValidador());
var ListarExpedientes = new CasoDeUsoListarExpedientes(repo);

var AgregarTramite = new CasoDeUsoTramiteAlta(repoT, new TramiteValidador());
var ListarTramites = new CasoDeUsoListarTramites(repoT);
var EliminarTramite=new CasoDeUsoTramiteBaja(repoT);

//creo los expedientes
Expediente exp = new Expediente() {caratula="Random"};
Expediente exp2 = new Expediente() {caratula="Prueba"};

//Creo los trámites
Tramite tra1=new Tramite() {Contenido="Test"};
Tramite tra2=new Tramite() {Contenido="Xes"};
Tramite tra3=new Tramite() {Contenido="Res"};
Tramite tra4=new Tramite() {Contenido="Mes"};

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
}
catch (System.Exception ex)
{
    Console.WriteLine(ex.Message);
}

