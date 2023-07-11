using Modelos.Modelos;

namespace Interfaces.Dominio;

public interface ICreadorPolizas
{
    Task CrearAsync(SolicitudCreacionPoliza solicitudCreacionPoliza);
}