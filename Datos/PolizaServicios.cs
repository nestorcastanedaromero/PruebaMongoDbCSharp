using System.Linq.Expressions;
using Compartidos.Excepciones;
using Compartidos.Infraestructura;
using Datos.Properties;
using Interfaces.Datos;
using Microsoft.Extensions.Options;
using Modelos.Entidades;
using MongoDB.Driver;

namespace Datos
{
    public class PolizasServicios : IPolizasServicios
    {
        public static readonly string NoSeEncontroPoliza = Resources.NoSeEncontroPoliza;

        private readonly IMongoCollection<Poliza> _polizasCollection;

        public PolizasServicios(IOptions<ConfiguracionConexionMongo> configuracionConexionMongo)
        {
            var cliente = new MongoClient(configuracionConexionMongo.Value.StringDeConexion);
            var baseDatos = cliente.GetDatabase(configuracionConexionMongo.Value.NombreBaseDatos);

            _polizasCollection = baseDatos.GetCollection<Poliza>(configuracionConexionMongo.Value.ColeccionDePruebas);
        }

        public async Task<List<Poliza>> ObtenerAsync() =>
            await _polizasCollection.Find(_ => true).ToListAsync();

        public async Task<Poliza> ObtenerAsync(string filtro)
        {
            if (Guid.TryParse(filtro, out var guid))
                return await ObtenerDocumento(poliza => poliza.Id == guid);

            return await ObtenerDocumento(poliza => poliza.Placa == filtro);
        }

        private async Task<Poliza> ObtenerDocumento(Expression<Func<Poliza, bool>> expression)
        {
            var documento = await _polizasCollection.Find(expression).FirstOrDefaultAsync();

            if (documento == null)
                throw new RegistroNoEncontrado(NoSeEncontroPoliza);

            return documento;
        }

        public async Task CrearAsync(Poliza nuevaPoliza) =>
            await _polizasCollection.InsertOneAsync(nuevaPoliza);

        public async Task ActualizarAsync(Guid id, Poliza nuevosDatos) =>
            await _polizasCollection.ReplaceOneAsync(poliza => poliza.Id == id, nuevosDatos);

        public async Task RemoverAsync(Guid id) =>
            await _polizasCollection.DeleteOneAsync(poliza => poliza.Id == id);
    }
}
