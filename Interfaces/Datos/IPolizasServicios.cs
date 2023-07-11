using Modelos.Entidades;

namespace Interfaces.Datos;

public interface IPolizasServicios
{
    Task<List<Poliza>> ObtenerAsync();
    Task<Poliza> ObtenerAsync(string filtro);
    Task CrearAsync(Poliza nuevaPoliza);
    Task ActualizarAsync(Guid id, Poliza nuevosDatos);
    Task RemoverAsync(Guid id);
}