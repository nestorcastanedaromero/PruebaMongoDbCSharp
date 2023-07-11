using Compartidos.Excepciones;
using Compartidos.Utilidades;
using Modelos.Modelos;
using Modelos.Properties;

namespace Modelos.Entidades;

public class Poliza
{
    public static readonly string FechaPolizaNoVigente = Resources.FechaPolizaNoVigente;
    public static readonly string FechaDePolizaInvalida = Resources.FechaDePolizaInvalida;
    
    public Guid Id { get; private set; }
    public string Identificacion { get; private set; }
    public string NombreCliente { get; private set; }
    public DateTime FechaNacimientoCliente { get; private set; }
    public DateTime FechaTomaPoliza { get; private set; }
    public DateTime FechaVencimientoPoliza { get; private set; }
    public List<string> Coberturas { get; private set; }
    public decimal ValorMaximoPoliza { get; private set; }
    public string NombrePlanPoliza { get; private set; }
    public string CiudadRecidenciaCliente { get; private set; }
    public string DireccionResidenciaCliente { get; private set; }
    public string Placa { get; private set; }
    public string Modelo { get; private set; }
    public bool TieneInspeccion { get; private set; }

    public Poliza(SolicitudCreacionPoliza solicitudCreacion, IFecha fechaActual)
    {
        ValidarParametros(solicitudCreacion.FechaTomaPoliza, solicitudCreacion.FechaVencimientoPoliza, fechaActual);

        Identificacion = solicitudCreacion.Identificacion;
        NombreCliente = solicitudCreacion.NombreCliente;
        FechaNacimientoCliente = solicitudCreacion.FechaNacimientoCliente;
        FechaVencimientoPoliza = solicitudCreacion.FechaVencimientoPoliza;
        FechaTomaPoliza = solicitudCreacion.FechaTomaPoliza;
        Coberturas = solicitudCreacion.Coberturas;
        ValorMaximoPoliza = solicitudCreacion.ValorMaximoPoliza;
        NombrePlanPoliza = solicitudCreacion.NombrePlanPoliza;
        CiudadRecidenciaCliente = solicitudCreacion.CiudadRecidenciaCliente;
        DireccionResidenciaCliente = solicitudCreacion.DireccionResidenciaCliente;
        Placa = solicitudCreacion.Placa;
        Modelo = solicitudCreacion.Modelo;
        TieneInspeccion = solicitudCreacion.TieneInspeccion;
    }

    private static void ValidarParametros(DateTime fechaTomaPoliza, DateTime fechaVencimientoPoliza, IFecha fecha)
    {
        LanzarExcepcionSiFechaPolizaNoVigente(fechaVencimientoPoliza, fecha);
        LanzarExcepcionFechaInicioMayorAFinal(fechaTomaPoliza, fechaVencimientoPoliza);
    }

    private static void LanzarExcepcionFechaInicioMayorAFinal(DateTime fechaTomaPoliza, DateTime fechaVencimientoPoliza)
    {
        if (fechaTomaPoliza > fechaVencimientoPoliza)
            throw new Error(FechaDePolizaInvalida);
    }

    private static void LanzarExcepcionSiFechaPolizaNoVigente(DateTime fechaVencimientoPoliza, IFecha fecha)
    {
        if (fechaVencimientoPoliza < fecha.Hoy())
            throw new Error(FechaPolizaNoVigente);
    }
}

