using Compartidos.Infraestructura;
using Datos;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mongo2Go;
using MongoDB.Driver;

namespace Pruebas;

public class ContextoMongoTestBase
{
    private static MongoDbRunner? _mongoDbRunner;
    private static MongoClient? _cliente { get; set; }
    private static ConfiguracionConexionMongo? _configurationMongo;
    private static bool _contextoEstaInicializado = false;
    protected static PolizasServicios _polizasServicios { get; private set; }

    public ContextoMongoTestBase()
    {
        if (!_contextoEstaInicializado)
            InicializarContexto();
    }

    public void InicializarContexto()
    {
        _contextoEstaInicializado = true;
        _mongoDbRunner = MongoDbRunner.Start();
        _cliente = new MongoClient(_mongoDbRunner.ConnectionString);
        _configurationMongo = new ConfiguracionConexionMongo()
        {
            StringDeConexion = _mongoDbRunner.ConnectionString,
            NombreBaseDatos = "Pruebas",
            ColeccionDePruebas = "Pruebas"
        };
        IOptions<ConfiguracionConexionMongo> configuracion = Options.Create(_configurationMongo);
        _polizasServicios = new PolizasServicios(configuracion);
    }

    [TestCleanup]
    public void LimpiarTest() => LimpiarColeccionesMongo();

    private void LimpiarColeccionesMongo()
    {
        IMongoDatabase? baseDatos = _cliente?.GetDatabase(_configurationMongo?.NombreBaseDatos);
        baseDatos?.DropCollection(_configurationMongo?.ColeccionDePruebas);
    }

    public static void TerminarMongoDb()
    {
        _mongoDbRunner?.Dispose();
        _mongoDbRunner = null;
    }
}
