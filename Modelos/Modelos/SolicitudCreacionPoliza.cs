namespace Modelos.Modelos;

public record SolicitudCreacionPoliza(
    string Identificacion,
    string NombreCliente,
    DateTime FechaNacimientoCliente,
    DateTime FechaTomaPoliza,
    DateTime FechaVencimientoPoliza,
    List<string> Coberturas,
    decimal ValorMaximoPoliza,
    string NombrePlanPoliza,
    string CiudadRecidenciaCliente,
    string DireccionResidenciaCliente,
    string Placa,
    string Modelo,
    bool TieneInspeccion);
    

