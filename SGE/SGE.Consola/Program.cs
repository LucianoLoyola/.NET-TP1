using SGE.Aplicacion;
using SGE.Repositorios;

//configuro las dependencias 
IExpedienteRepositorio repo = new RepositorioExpedienteTXT();

//creo los casos de uso 
var AgregarExpediente = new CasoDeUsoExpedienteAlta(repo, new ExpedienteValidador());
var ListarExpedientes = new CasoDeUsoListarExpedientes(repo);

//creo los expedientes
Expediente exp = new Expediente() {caratula="Random"};
Expediente exp2 = new Expediente() {caratula="Prueba"};

//ejecuto los casos de uso con validaciones 
try
{
    AgregarExpediente.Ejecutar(exp,exp.Id);
    AgregarExpediente.Ejecutar(exp2,exp2.Id);
    var lista = ListarExpedientes.Ejecutar();
    foreach(Expediente e in lista){
        Console.WriteLine(e);
    }
}
catch (System.Exception ex)
{
    Console.WriteLine(ex.Message);
}

